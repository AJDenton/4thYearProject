using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Defining a game object which will hold the player object.
    public GameObject player;

    // Vector3 variable for offsetting the camera
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        // Setting the cameraOffset
        cameraOffset = new Vector3(0, 1, -10);

        // Moving the camera alongside the player position
        transform.position = player.transform.position + cameraOffset;
    }
}
