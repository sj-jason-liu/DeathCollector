using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingSoul : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    void Update()
    {
        //move to right
        transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit == null)
            return;
        hit.Damage();
    }
}
