using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSoul : MonoBehaviour
{
    private Animator _animator;

    private SoulLauncher _launcher;

    [SerializeField]
    private GameObject _soulPrefab;
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if(_animator == null)
        {
            Debug.LogError("Animator is NULL!");
        }

        _launcher = GetComponentInChildren<SoulLauncher>();
        if(_launcher == null)
        {
            Debug.LogError("SoulLauncher is NULL!");
        }
    }

    void Update()
    {
        SoulsFiring();
    }

    void SoulsFiring()
    {
        if (Input.GetKeyDown(KeyCode.F) && GameManager.Instance.GetCurrentSouls() > 0)
        {
            _animator.SetTrigger("Firing"); //fire souls
            GameManager.Instance.UpdateSouls(-1); //minus 1 from gamemanager
            
            //instantiate a soul prefab 
            //calling method to instantiate a soul prefab from child object
            _launcher.LaunchSoul();
        }  
    }
}
