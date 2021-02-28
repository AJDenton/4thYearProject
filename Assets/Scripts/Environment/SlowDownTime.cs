using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    //public GameObject player;
    public float slowTimer = 3.0f;
    public float slowDownSpeed = 0.3f;
    public float normalSpeed = 1.0f;
    public bool slowMo = false;

    // Update is called once per frame
    void Update()
    {
        //slowMotion();
    }

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
            slowMo = true;
            Time.timeScale = slowDownSpeed;
            Debug.Log("Slow Motion Working");
            //StartCoroutine(SlowMoCoroutine());
    }

    void regularSpeed()
    {
        slowMo = false;
        Time.timeScale = normalSpeed;
        //StartCoroutine(SlowMoCoroutine());
    }

/*    IEnumerator SlowMoCoroutine()
    {
        yield return new WaitForSeconds(slowTimer);
        slowMo = false;
        Time.timeScale = normalSpeed;
    } */   
}
