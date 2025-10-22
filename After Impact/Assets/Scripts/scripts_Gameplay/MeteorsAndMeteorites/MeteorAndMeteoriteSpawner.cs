using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: 
 * Created By: 
 * Purpose: This class is responsible for controlling the spawning of meteors and meteorites in the game.
 */

//MeteorAndMeteoriteSpawner Class - Spawns meteors and meteorites at random positions above the screen
public class MeteorAndMeteoriteSpawner : MonoBehaviour {

    [Header("Meteor And Meteorite Settings")]
    public GameObject meteorPrefab;
    public float spawnRate = 2f;
    public float minX = 6f;  // Adjust depending on camera size
    public float maxX = 9f;
    public float spawnY = 6f; // Slightly above the top of the screen

    //Start Method - Called before the first frame update
    private void Start() {
    
        //Invoke the SpawnMeteorAndMeteorite method repeatedly at the defined spawn rate
        InvokeRepeating(nameof(SpawnMeteorAndMeteorite), 0f, spawnRate);
    
    } //End of Start Method

    //SpawnMeteorAndMeteorite Method - Spawns a meteor or meteorite at a random position above the screen
    private void SpawnMeteorAndMeteorite() {

        float randomX = Random.Range(minX, maxX); //Get and store a random X position within the defined range
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0); //Create a spawn position vector using the random X and fixed Y

        Instantiate(meteorPrefab, spawnPos, Quaternion.identity); //Instantiate the meteor or meteorite prefab at the spawn position with no rotation

    } //End of SpawnMeteorAndMeteorite Method

} //End of MeteorAndMeteoriteSpawner Class
