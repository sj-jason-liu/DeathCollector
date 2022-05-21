using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform _childTransform;

    private MeshRenderer _mesh;

    private Color _checkedColor;
    
    void Start()
    {
        _childTransform = transform.GetChild(0);
        _mesh = GetComponent<MeshRenderer>();
        _checkedColor = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _mesh.material.color = _checkedColor;
            GameManager.Instance.UpdateCheckpoint(_childTransform.position);
            _childTransform.gameObject.SetActive(false);
        }
    }
}
