using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Speed for player movement
    public float speed;
    //Seeting the move value to the pre-defined control scheme (Horizontal) in Unity.
    public float horizInput;
    //Jump force for player to jump upwards on Y axis
    public float jumpForce = 8.0f;
    //Boolean to check if the player is on the ground (for jumping)
    public bool isGrounded = true;
    //Obtaining the rigidbody for the player
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning the rigidbody to a variable
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Assigning the horizInput to Unity's horizontal axis inputs
        horizInput = Input.GetAxis("Horizontal");
        //Making movement for the player's horizontal movements
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizInput);

        //Checking if the player is on the ground and if the player has input the Space key
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            //Adding force to the players rigidbody to create a jump
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //Making the isGrounded bool equal false when the player is not touching the ground
            isGrounded = false;
        }

    }

    //Checking for collisions on the gameObject (player)
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the player is touching another object with the tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Making the isGrounded bool equal true if the player is colliding with the ground
            isGrounded = true;
        }
    }

}
