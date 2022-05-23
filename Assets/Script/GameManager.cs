using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL!");
            }
            return _instance;
        }
    }

    private int souls;

    private Player _player;

    private void Awake()
    {
        _instance = this;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Player is NULL!");
        }
    }

    //Calculate collected souls
    public void UpdateSouls(int soul)
    {
        souls += soul;
        if (souls <= 0)
            souls = 0; 
        UIManager.Instance.UpdateText(souls); //updated in UI.
    }

    public int GetCurrentSouls()
    {
        return souls;
    }

    public void UpdateCheckpoint(Vector3 newSpawnPosition)
    {
        //receiving the new spawn position
        //sending new position to Player
        _player.UpdateSpawnPosition(newSpawnPosition);
    }
}
