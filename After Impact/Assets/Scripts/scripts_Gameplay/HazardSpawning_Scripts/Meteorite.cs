using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: October 30, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for handling the behavior of meteorite hazards in the game.
 */

//Meteorite Class - Handles the behavior of meteorite hazards in the game
public class Meteorite : MonoBehaviour {

    [Header("Meteorite Settings")]
    public float meteoriteSpeed = 5f; //Speed at which the meteorite falls
    public float meteoriteLifetime = 8f; //Lifetime of the meteorite before it gets destroyed

    private Vector2 meteoriteMovementDirection; //Direction of the meteorite movement


    //Start Method - Is called before the first frame update
    void Start() {

        //Randomize the initial horizontal direction slightly for variation
        float xDir = Random.Range(-0.5f, -0.2f); 

        //Set the meteorite movement direction from the top-right to the bottom-left of the screen
        meteoriteMovementDirection = new Vector2(xDir, -1f).normalized;

        //Randomize the speed slightly for variation
        meteoriteSpeed += Random.Range(-1f, 2f); 

        //Set a random angular velocity for rotation effect
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200f, 200f);

        //Destroy(gameObject, meteoriteLifetime); //Destroy the meteorite after its lifetime expires

    } //End of Start Method

    //Update Method - Is called once per frame
    void Update() {

        //Move the meteorite in the set direction at the set speed
        transform.Translate(meteoriteMovementDirection * meteoriteSpeed * Time.deltaTime, Space.World);

    } //End of Update Method

    //OnBecameInvisible Method - Is called when the meteorite goes off-screen
    void OnBecameInvisible() { Destroy(gameObject); }

} //End of Meteorite Class
