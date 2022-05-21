using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    //[SerializeField] KeyType keyType;
    //[SerializeField] float rotationSpeed = 50;
    //[SerializeField] float moveDistance = 3f;
    //[SerializeField] float moveSpeed = 2f;

    //void Update()
    //{
    //    Animate();
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    Inventory inventory = other.GetComponent<Inventory>();

    //    if (inventory == null) { return; }
        
    //    inventory.AddKey(keyType);
    //    Destroy(gameObject);
    //}

    //void Animate()
    //{
    //    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    //    Vector3 newPos = transform.position;
    //    newPos.y = moveDistance * (Mathf.Sin(Time.time * moveSpeed - (Mathf.PI / 2f))) + moveDistance;
    //    transform.position = newPos;
    //}
}
