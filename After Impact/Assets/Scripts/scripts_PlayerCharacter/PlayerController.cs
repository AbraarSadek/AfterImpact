using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: 
 * Created By: 
 * Purpose: This class is responsible for controlling the player character's behavior.
 */

//PlayerController Class - Handles the player character 
public class PlayerController : MonoBehaviour { 

    //Reference to game object component
    private Rigidbody2D rb; //Rigidbody2D component reference

    //Player movement variables
    [Header("Player Movement")]
    public float playerSpeed = 5f; //Float variable to set player speed

    private Vector2 playerDirection; //Vector2 variable to hold player direction

    //Player boundary variables
    //[Header("Player Boundaries")]
    //public float minY = -3.8f;
    //public float maxY = 3.8f;

    //Start Method - Called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody2D>();

    } //End of Start Method

    //Update Method - Called once per frame
    void Update() {

        float directionY = Input.GetAxisRaw("Vertical"); //Get and store vertical input
        playerDirection = new Vector2(0, directionY).normalized; //Get and store the normalized direction vector

    } //End of Update Method

    //FixedUpdate Method - Called at a fixed interval and is independent of frame rate
    void FixedUpdate() {

        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed); //Set the player's velocity based on input and speed

        //float clampedY = Mathf.Clamp(transform.position.y, minY, maxY); //Clamp the player's Y position within the defined boundaries
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); //Update the player's position with the clamped Y value

    } //End of FixedUpdate Method

} //End of PlayerController Class