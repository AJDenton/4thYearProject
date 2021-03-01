﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

   //Starting/full health 
    public int fullHealth = 100;
    //Health for the player
    public int health;


    //Distance between the object and the player
    private float objectDist;
    //Distance in which the player can interact with the object
    private float pushDist = 1.2f;
    //Speed for player movement
    public float speed;
    //Seeting the move value to the pre-defined control scheme (Horizontal) in Unity.
    public float horizInput;
    //Jump force for player to jump upwards on Y axis
    public float jumpForce = 30f;
    //Set amount od force for knockback during enemy collision
    public float knockBackForce = 10;
    //How long the damage will last/how long it will be until the player can be damaged again
    public float damageDuration = 0.5f;

    //Boolean to check if the player is on the ground (for jumping)
    public bool isGrounded;
    //Checking if the game is over.
    public bool gameOver = false;
    //checking for whether the player is damaged or not
    private bool isDamaged;

    //Obtaining the rigidbody for the player
    public Rigidbody playerRB;
    //Object rigidbody
    public Rigidbody objectRb;
    //Push Object gameObject
    public GameObject pushObject;
    //Game Object for the dangers
    public GameObject hazard;

    
    //Reference to my animator controller
    public Animator playerAnim;

    private int Health { get { return health; } }
    private Danger dangerScript;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        //Setting health to full health at start of game
        health = fullHealth;
        //Finding the interactive gameObject from within the scene
        pushObject = GameObject.FindGameObjectWithTag("PushBox");
        objectRb = pushObject.gameObject.GetComponent<Rigidbody>();
        
        //Assigning the rigidbody to a variable
        playerRB = GetComponent<Rigidbody>();

        //Assigning the animation controller 
        playerAnim = GetComponent<Animator>();

        //getting the script of the environmental dangers in the scene
        dangerScript = hazard.GetComponent<Danger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calling functions
        PlayerMovement();
        moveObjects();
        GameOver();
        
        //Assigning the horizInput to Unity's horizontal axis inputs
        //horizInput = Input.GetAxis("Horizontal");
        //Making movement for the player's horizontal movements
        //transform.Translate(Vector3.right * speed * Time.deltaTime * horizInput);

        //Checking if the player is on the ground and if the player has input the Space key
        /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        { 
            //Adding force to the players rigidbody to create a jump
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Making the isGrounded bool equal false when the player is not touching the ground
            isGrounded = false;
        }*/

    }

    //Checking for collisions on the gameObject (player)
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject)
        {
            isGrounded = true;
        } 
        
        //Checking if the player is colliding with a gameObject with the Tag "Hazard"
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Setting a knockback vector3 value so that the player's position is taken away from the hazard position
            Vector3 knockBack = playerRB.gameObject.transform.position - other.transform.position;
            //Add force to the player rigidbody when it comes into contact with the hazardous object
            playerRB.AddForce(knockBack * knockBackForce, ForceMode.Impulse);
            
            //Is the player is NOT damaged, set it to true
            if(isDamaged == false) {
                isDamaged = true;
                //Take the pre-defined damage (in the danger script) away from the health value
                health -= dangerScript.damage;
                //Start the routine timer for the player so that damage is not conitnuously happening.
                StartCoroutine(DamageRoutine());
            }
        }

        
    }

    void PlayerMovement()
    {
        if (Input.GetKey(GameManager.GM.left))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(GameManager.GM.right))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(GameManager.GM.jump) && isGrounded == true)
        {
            //Debug.Log("HECK");
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }



    //CoRoutine for when damage is taken, this will allow halfa second to not lose health
    IEnumerator DamageRoutine()
    {
        //Setting the seconds to the damageDuration value
        yield return new WaitForSeconds(damageDuration);
        isDamaged = false;
    }

    void moveObjects()
    {
        //PlayerController playerController = player.GetComponent<PlayerController>();
        //Setting the offset for the object when the player is pushing the object
        Vector3 pushOffsetRight = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z);
        //Vector3 pushOffsetLeft = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y, player.transform.position.z);

        //Detecting the distance between the object and the player
        objectDist = Vector3.Distance(gameObject.transform.position, pushObject.transform.position);

        //Button Mashing System
        //If the distance between the object and player is less than the pushDist, the player can pick up and push the object
/*        if (objectDist <= pushDist && Input.GetMouseButtonDown(0))
        {
            //Start the timer
            //StartCoroutine(PushCoRoutine());



            //Push the object away in once impulse
            ///////////objectRb.AddForce(new Vector3(1000, 0, 0), ForceMode.Impulse);

            //Debug.Log("HEYHEY");
            //gameObject.transform.position = pushOffsetRight;
            //Slow the player down
            //playerController.speed = playerController.speed / 2;

        }*/
        //If the distance between the object and player is less than the pushDist, the player can pick up and push the object
        if (objectDist <= pushDist && Input.GetMouseButton(0))
        {
            //Start the timer
            //StartCoroutine(PushCoRoutine());

            //Push the object away in once impulse
            //objectRb.AddForce(new Vector3(100, 0, 0), ForceMode.Impulse);
            InteractParent();

            /////////////objectRb.transform.parent = gameObject.transform;
            //Debug.Log("HEYHEY");
            //gameObject.transform.position = pushOffsetRight;
            //Slow the player down
            speed = 4;

        }
        else
        {

            DisableInteractParent();
            //Revert to the normal player speed
            speed = 8;
        }
    }

    //Hold the object
    void InteractParent()
    {
        pushObject.transform.parent = gameObject.transform;
    }

    //Stop holding the object
    void DisableInteractParent()
    {
        pushObject.transform.parent = null;
    }


    //If gameOver is true, change the scene to the game over scene.
    void GameOver()
    {
        if(health <= 0)
        {
            gameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Game Over!");
        }
    }
}
