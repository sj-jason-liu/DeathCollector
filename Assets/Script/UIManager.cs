using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is NULL!");
            }
            return _instance;
        }
    }

    [SerializeField]
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateText(int soulsCount)
    {
        _text.text = "Souls: " + soulsCount;
    }
}
