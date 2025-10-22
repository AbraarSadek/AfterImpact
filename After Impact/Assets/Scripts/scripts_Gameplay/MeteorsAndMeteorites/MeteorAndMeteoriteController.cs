using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created Date: 
 * Created By: 
 * Purpose: This class is responsible for controlling the behavior of meteors and meteorites in the game.
 */

//MeteorAndMeteoriteController Class - Controls the behavior of meteors and meteorites in the game
public class MeteorAndMeteoriteController : MonoBehaviour {

    [Header("Meteor and Meteorite Settings")]
    [SerializeField] float fallSpeed = 5.0f;
    [SerializeField] float horizontalDrift = 1.0f; // optional slight side movement

    //Update Method - Is called once per frame
    private void Update() {

        // Move downwards, with optional horizontal drift
        Vector3 moveDir = Vector3.down + Vector3.left * horizontalDrift * 0.2f;
        transform.position += moveDir.normalized * fallSpeed * Time.deltaTime;

    } //End of Update Method

} //End of MeteorAndMeteoriteController Class