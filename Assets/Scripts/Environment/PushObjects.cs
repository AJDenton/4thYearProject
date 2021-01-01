using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjects : MonoBehaviour
{
    //Distance between the object and the player
    private float objectDist;
    //Distance in which the player can interact with the object
    private float pushDist = 2f;
    //The player gameObject
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Finding the player gameObject from within the scene
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the moveObjects function
        moveObjects();
    }

    void moveObjects()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        //Setting the offset for the object when the player is pushing the object
        Vector3 pushOffsetRight = new Vector3(player.transform.position.x + 1f, gameObject.transform.position.y, player.transform.position.z);
        //Vector3 pushOffsetLeft = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y, player.transform.position.z);

        //Detecting the distance between the object and the player
        objectDist = Vector3.Distance(transform.position, player.transform.position);

        //If the distance between the object and player is less than the pushDist, the player can pick up and push the object
        if (objectDist <= pushDist && Input.GetMouseButton(0))
        {
            //Debug.Log("HEYHEY");
            gameObject.transform.position = pushOffsetRight;
            //Slow the player down
            playerController.speed = playerController.speed / 2;
        }
        else
        {
            //Revert to the normal player speed
            playerController.speed = 8;
        }
    }
}
