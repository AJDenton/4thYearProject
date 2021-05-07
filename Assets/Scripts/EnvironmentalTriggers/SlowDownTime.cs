using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    //public GameObject player;
    public float slowTimer = 3.0f;
    public float slowDownSpeed = 0.3f;
    public float normalSpeed = 1.0f;


    //When the player enters a trigger area
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") { 
        slowMotion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") { 
        regularSpeed();
        }
    }

    void slowMotion()
    {            
            Time.timeScale = slowDownSpeed;
    }

    void regularSpeed()
    {
        Time.timeScale = normalSpeed;
    }

}
