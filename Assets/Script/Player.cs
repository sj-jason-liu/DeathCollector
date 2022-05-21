using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

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

    private bool _hasDoubleJump;
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
            Debug.LogError("Character Controller is NULL!");

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

        if (_controller.isGrounded)
        {
            _hasDoubleJump = false;
            if (Input.GetKeyDown(KeyCode.Space)) //jump
            {
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (!_hasDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight * _doubleJumpAdjust;
                _hasDoubleJump = true;
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
