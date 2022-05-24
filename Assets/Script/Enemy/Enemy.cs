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
    protected Transform model;

    protected Vector3 targetPosition;

    protected bool movingLeft;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if(anim == null)
        {
            Debug.LogError("Animator of " + gameObject + " is null!");
        }
        model = anim.gameObject.transform;
        if(model == null)
        {
            Debug.LogError("Enemy model: " + model.gameObject + " is null!");
        }
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        //if current animation state is isle
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Zombie Idle"))
            return;
        Movement();
    }

    public virtual void Movement()
    {
        float facing = movingLeft ? -90 : 90;
        model.transform.localRotation = Quaternion.Euler(model.transform.rotation.x, facing, model.transform.rotation.z);
        
        switch(movingLeft)
        {
            case true:
                targetPosition = waypointB.position;
                break;
            case false:
                targetPosition = waypointA.position;
                break;
        }

        if(Vector3.Distance(transform.position, targetPosition) <= 0f)
        {
            movingLeft = !movingLeft;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public virtual void Attack()
    {

    }
}
