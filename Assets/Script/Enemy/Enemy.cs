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

    public virtual void Attack()
    {

    }
}