using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField]
    private float _moveDistance = 3f;
    [SerializeField]
    private float _moveSpeed = 2f;
    private float _absorbSpeed;
    private float _tempYValue;

    private bool _hasDetectPlayer;

    private Player _player;

    private Vector3 _targetPos;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        _tempYValue = transform.position.y;
    }

    void Update()
    {
        if(!_hasDetectPlayer)
        {
            FloatingAnimation();
        }
        else
        {
            //move toward player
            _targetPos = _player.gameObject.transform.position;
            _absorbSpeed += _moveSpeed * (Time.deltaTime/2);
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _absorbSpeed);
        }

        //if(Vector3.Distance(transform.position, _targetPos) < 0.001f)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _hasDetectPlayer = true;
            //_targetPos = other.transform.position;
        }
    }

    void FloatingAnimation()
    {
        Vector3 newPos = transform.position;
        newPos.y = _tempYValue + _moveDistance * (Mathf.Sin(Time.time * _moveSpeed)) + _moveDistance;
        transform.position = newPos;
    }
}
