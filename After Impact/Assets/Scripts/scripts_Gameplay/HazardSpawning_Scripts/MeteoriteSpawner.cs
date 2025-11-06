using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: October 30, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for handling the spawning of meteorite hazards in the game.
 */

//MeteoriteSpawner Class - Responsible for spawning meteorites in the game
public class MeteoriteSpawner : MonoBehaviour {

    [Header("Meteorite Spawner Settings")]
    public GameObject meteoritePrefab; //Prefab for the meteorite hazard
    public float spawnRate = 1f; //Rate at which meteorites are spawned
    public float xRange = 2f; //Horizontal range for spawning meteorites
    public float yOffset = 1f; //Vertical offset for spawning meteorites

    public float timer; //Timer to track the time between meteorite spawns

    //Update Method - Is called once per frame
    void Update() {

        timer += Time.deltaTime; //Increment the timer by the time elapsed since the last frame

        //If-Statement - Check If It's Time To Spawn A New Meteorite
        if (timer >= 2f / spawnRate) {

            SpawnMeteorite(); //Call the SpawnMeteorite Method
            timer = 0f; //Reset the timer

        } //End of If-Statement

    } //End of Update Method

    //SpawnMeteorite Method - Spawns a new meteorite at a random position within the defined range
    void SpawnMeteorite() {

        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)); //Get the top-right corner of the camera view in world coordinates

        float spawnX = topRight.x + Random.Range(yOffset, xRange); //Calculate a random X position for spawning the meteorite
        float spawnY = topRight.y + yOffset; //Calculate the Y position for spawning the meteorite

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f); //Create the spawn position vector

        Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);

    } //End of SpawnMeteorite Method

} //End of MeteoriteSpawner Class
