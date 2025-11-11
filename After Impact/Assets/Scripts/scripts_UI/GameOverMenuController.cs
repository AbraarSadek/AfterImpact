using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created Date: October 22, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for controlling the game over menu UI interactions.
 */

//GameOverMenuController Class - Used to control the game over menu UI
public class GameOverMenuController : MonoBehaviour {

    //PlayAgainButton Method - Loads the level scene when the "PLAY AGAIN" button is pressed
    public void PlayAgainButton() { SceneManager.LoadSceneAsync(2); }


    //SettingsButton Method - Loads the settings scene when the "SETTINGS" button is pressed
    public void SettingsButton() {

        SceneTracker.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex; //Store the current scene index before loading the settings scene
        SceneManager.LoadSceneAsync(1);

    } //End of SettingsButton Method

    //QuitGameButton Method - Loads the main menu scene when the "QUIT GAME" button is pressed
    public void QuitGameButton() { SceneManager.LoadSceneAsync(0); }
    private void Start()
    {

    }

} //End of GameOverMenuController Class
