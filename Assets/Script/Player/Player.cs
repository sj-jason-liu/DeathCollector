using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAnimation _anim;
    private Animator _animator;
    [SerializeField]
    private GameObject _model;

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _gravity = 1f;
    [SerializeField]
    private float _jumpHeight = 10f;
    [SerializeField]
    [Range(0.5f, 0.8f)]
    private float _doubleJumpAdjust;
    private float _yVelocity;

    private Vector3 _spawnPosition;

    private bool _isJumping;
    private bool _hasDoubleJump;
    private bool _isAttacking;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("Character Controller is NULL!");
        _anim = GetComponentInChildren<PlayerAnimation>();
        if (_anim == null)
            Debug.LogError("Player Animator is NULL!");
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
            Debug.LogError("Animator is NULL!");

        _spawnPosition = transform.position;
    }

    void Update()
    {
        if(!_isAttacking)
        {
            Movement();
        }
        Attack();
    }

    public void UpdateSpawnPosition(Vector3 newPosition)
    {
        _spawnPosition = newPosition;
    }

    void Spawning()
    {
        _controller.enabled = false;
        transform.position = _spawnPosition;

        StartCoroutine(RestartController());
    }

    public void Death()
    {
        //handleing death routine
        //spawning again
        GameManager.Instance.UpdateSouls(1);
        Spawning();

    }

    IEnumerator RestartController()
    {
        yield return new WaitForSeconds(0.1f);
        _controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.moveDirection.y == 1)
        {
            _yVelocity -= _gravity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit == null)
            return;
        hit.Damage();
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMove, 0, 0);
        Vector3 velocity = movement * _speed;
        _animator.SetFloat("Moving", Mathf.Abs(horizontalMove));
        //_anim.Moving(Mathf.Abs(horizontalMove));
        
        if(horizontalMove != 0)
        {
            Vector3 facing = _model.transform.localEulerAngles;
            facing.y = movement.x > 0 ? 90 : -90;
            _model.transform.localEulerAngles = facing;
        }
        
        if (_controller.isGrounded)
        {
            _hasDoubleJump = false;
            _isJumping = false;
            _animator.SetBool("Jumping", _isJumping);
            //_anim.Jumping(_isJumping);
            if (Input.GetKeyDown(KeyCode.Space)) //jump
            {
                _yVelocity = _jumpHeight;
                _isJumping = true;
                //_anim.Jumping(_isJumping);
                _animator.SetBool("Jumping", _isJumping);
            }
        }
        else
        {
            if (!_hasDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight * _doubleJumpAdjust;
                _hasDoubleJump = true;
                _animator.SetTrigger("DoubleJump");
                //_anim.DoubleJump();
            }
            else
            {
                _yVelocity -= _gravity;
            }
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }


    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!_isAttacking)
            {
                _isAttacking = true;
                Debug.Log("Attacking!");
                _animator.SetTrigger("Punch");
            }           
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Punching")) //After 1st punch
            {
                _animator.SetTrigger("Punch");
            }
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("LeftPunching"))
            {
                _animator.SetTrigger("Punch");
            }
        }

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Punching")
            || _animator.GetCurrentAnimatorStateInfo(0).IsName("LeftPunching")
            || _animator.GetCurrentAnimatorStateInfo(0).IsName("Cross Punch"))
            return;
        _isAttacking = false;
        Debug.Log("Finish attacking!");
    }
}
