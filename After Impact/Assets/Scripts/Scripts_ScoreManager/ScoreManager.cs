using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Purpose: This Script is used to calculate the score.
 * 
 * Created By: Abraar Sadek
 * Date Created: 10/16/2025
 * 
 * Modified By: Abraar Sadek
 * Date Last Modified: 10/16/2025
 * What Was Modified: Initial Creation
 */

//ScoreManager Class

public class ScoreManager : MonoBehaviour {

    [Header("Game Object Referances")]
    public TextMeshProUGUI scoreText; //Reference to the Score Text game object

    private float currentScore; //Float variable that will hold the current score

    //Update Method - Is Called Once Per Frame
    void Update() {


        //if (GameObject.FindGameObjectWithTag("Player") != null) {

        //    currentScore += 1 * Time.deltaTime; //Increase the current score by 1 every second
        //    scoreText.text = ((int)currentScore).ToString(); //Update the score text to show the current score

        //} //End of If-Statement

        //If-Statement - Check If The Player Game Object Exists In The Scene
        if (GameObject.FindGameObjectWithTag("Player") == null) return;

        currentScore += Time.deltaTime; //Increase the current score by 1 every second
        scoreText.text = ((int)currentScore).ToString(); //Update the score text to show the current score

    } //End of Update Method 

} //End of ScoreManager Class