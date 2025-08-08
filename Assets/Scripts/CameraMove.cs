using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject gamemanager;

    public float xoffset;
    public float yoffset;
    public bool followPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            if (Player.transform.position.x > gamemanager.GetComponent<GameManager>().MaxLeftX && Player.transform.position.x < gamemanager.GetComponent<GameManager>().MaxRightX)
            {
                this.transform.position = new Vector3(Player.transform.position.x + xoffset, this.transform.position.y + yoffset, this.transform.position.z);
            }
        }
        
    }
}
