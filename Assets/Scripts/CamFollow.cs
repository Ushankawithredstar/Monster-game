using System;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private static Transform player;
    public static Transform Player
    { 
        get { return player; }
        set { player = value; }
    }

    private Vector3 tempPos;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        //Debug.Log("Selected index: " + GameManager.instance.CharIndex);
    }

    // Update is called once per frame
    void Update()
    {

        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX) //fixes the camera position near the level borders
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX) 
        { 
            tempPos.x = maxX;
        }
        transform.position = tempPos;
    }
}
