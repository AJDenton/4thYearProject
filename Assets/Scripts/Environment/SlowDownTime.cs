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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slowMotion();
    }

    void slowMotion()
    {
        if (Input.GetKey(KeyCode.Z) && slowMo == false)
        {
            slowMo = true;
            Time.timeScale = slowDownSpeed;
            StartCoroutine(SlowMoCoroutine());
        }
    }

    IEnumerator SlowMoCoroutine()
    {
        yield return new WaitForSeconds(slowTimer);
        slowMo = false;
        Time.timeScale = normalSpeed;
    }    
}
