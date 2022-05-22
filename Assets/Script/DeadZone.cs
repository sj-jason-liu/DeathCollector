using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player is falling!");
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                //player falling function
                player.Death();
            }
        }
    }
}
