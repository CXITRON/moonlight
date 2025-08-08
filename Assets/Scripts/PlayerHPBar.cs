using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{

    public GameObject player;
    public GameObject fillarea;
    public Slider slHP;
    private float health_percantage;

     
    
    // Start is called before the first frame update

    void Awake()
    {
        slHP = GetComponent<Slider>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.GetComponent<PlayerBehavior>().maxHealth + " " + player.GetComponent<PlayerBehavior>().health);
        health_percantage = (float)player.GetComponent<PlayerBehavior>().health / player.GetComponent<PlayerBehavior>().maxHealth;

        if(health_percantage == 0) fillarea.gameObject.SetActive(false);
        else fillarea.gameObject.SetActive(true);
        slHP.value = health_percantage;
    }


}
