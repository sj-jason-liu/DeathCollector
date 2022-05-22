using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.LogError("Animator is NULL!");
        }
    }

    public void Moving(float movement)
    {
        _animator.SetFloat("Moving", movement);
    }

    public void Jumping(bool isJumping)
    {
        _animator.SetBool("Jumping", isJumping);
    }

    public void DoubleJump()
    {
        _animator.SetTrigger("DoubleJump");
    }
}
