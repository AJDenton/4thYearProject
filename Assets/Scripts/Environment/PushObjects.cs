using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjects : MonoBehaviour
{

    //The player gameObject
    public GameObject player;

    public float time = 5f;

    public Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        //Finding the player gameObject from within the scene
        player = GameObject.Find("Player");

        objectRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
