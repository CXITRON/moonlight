using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public GameObject camera;
    public GameObject gamemanager;
    public float MoveSpeed;
    public float offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(camera.transform.position.x > gamemanager.GetComponent<GameManager>().MaxLeftX && camera.transform.position.x < gamemanager.GetComponent<GameManager>().MaxRightX)
        {
            this.transform.position = new Vector3(camera.transform.position.x + camera.transform.position.x * MoveSpeed * -1 + offset, transform.position.y, transform.position.z);
        }
        //player.GetComponent<Rigidbody2D>().velocity.x;
    }
}
