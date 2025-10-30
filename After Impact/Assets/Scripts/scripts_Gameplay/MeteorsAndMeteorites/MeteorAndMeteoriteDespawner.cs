using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: 
 * Created By: 
 * Purpose: This class is responsible for controlling the despawning of meteors and meteorites in the game.
 */

//MeteorAndMeteoriteDespawner Class - Despawns meteors and meteorites when they go off-screen
public class MeteorAndMeteoriteDespawner : MonoBehaviour {

    [Header("Meteor And Meteorite Despawner Settings")]
    public GameObject meteorPrefab;
    public Transform spawnPoint;
    public float minX = 6f;
    public float maxX = 9f;
    public float spawnY = 6f;

    //OnTriggerEnter2D Method - Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D collision) {

        //If-Statement - Check if the collided object has the tag "Meteor" or "Meteorite"
        if (collision.CompareTag("Meteor") || collision.CompareTag("Meteorite")) {

            Destroy(collision.gameObject); //Destroy the collided meteor object

            float randomX = Random.Range(minX, maxX); //Get and store a random X position within the defined range
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0); //Create a spawn position vector using the random X and fixed Y
            Instantiate(meteorPrefab, spawnPos, Quaternion.identity); //Instantiate a new meteor at the spawn position with no rotation

        } //End of If-Statement

    } //End of OnTriggerEnter2D Method

} //End of MeteorAndMeteoriteDespawner Class
