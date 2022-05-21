using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform _childTransform;
    
    void Start()
    {
        _childTransform = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.UpdateCheckpoint(_childTransform.position);
        }
    }
}
