using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject _attackingSoul;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LaunchSoul()
    {
        Invoke("LaunchInvoke", 0.8f);
    }

    void LaunchInvoke()
    {
        //instantiate soul
        Vector3 currentPosition = transform.position;
        GameObject firedSoul = Instantiate(_attackingSoul, currentPosition, transform.rotation);
        firedSoul.transform.SetParent(gameObject.transform);
    }
}
