using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skinny : Enemy, IDamageable
{ 
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage()
    {
        Debug.Log("Hit " + transform.GetChild(0).name);
    }
}
