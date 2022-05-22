using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAnimation _anim;
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
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("Character Controller is NULL!");
        _anim = GetComponentInChildren<PlayerAnimation>();
        if (_anim == null)
            Debug.LogError("Player Animator is NULL!");

        _spawnPosition = transform.position;
    }

    void Update()
    {
        Movement();
    }

    public void UpdateSpawnPosition(Vector3 newPosition)
    {
        _spawnPosition = newPosition;
    }

    public void Spawning()
    {
        _controller.enabled = false;
        transform.position = _spawnPosition;

        StartCoroutine(RestartController());
    }

    public void Death()
    {
        //handleing death routine
        //spawning again
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

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMove, 0, 0);
        Vector3 velocity = movement * _speed;
        _anim.Moving(Mathf.Abs(horizontalMove));
        
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
            _anim.Jumping(_isJumping);
            if (Input.GetKeyDown(KeyCode.Space)) //jump
            {
                _yVelocity = _jumpHeight;
                _isJumping = true;
                _anim.Jumping(_isJumping);
            }
        }
        else
        {
            if (!_hasDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight * _doubleJumpAdjust;
                _hasDoubleJump = true;
                _anim.DoubleJump();
            }
            else
            {
                _yVelocity -= _gravity;
            }
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
