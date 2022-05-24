using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int souls;
    [SerializeField]
    protected float detectRange;
    [SerializeField]
    protected Transform waypointA, waypointB;

    protected Animator anim;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if(anim == null)
        {
            Debug.Log("Animator of " + gameObject + " is null!");
        }
    }

    private void Start()
    {
        Init();
    }

    public virtual void Movement()
    {

    }

    public virtual void Attack()
    {

    }
}
