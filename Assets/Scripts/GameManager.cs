using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;

    public static GameManager instance;

    private int _charIndex;
    public int CharIndex
    { 
        get { return _charIndex; } 
        set { _charIndex = value; }
     }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
