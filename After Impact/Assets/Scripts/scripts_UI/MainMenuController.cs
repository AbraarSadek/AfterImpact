using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created Date: October 22, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for controlling the main menu UI interactions.
 */

//MainMenuController Class - Used to control the main menu UI
public class MainMenuController : MonoBehaviour {

    [SerializeField] private AudioSource clickSFX;

    //PlayGameButton Method - Loads the level scene when the "PLAY GAME" button is pressed
    public void PlayGameButton() 
    { 
        StartCoroutine(LoadSceneWithSFX(2)); 
    }

    //SettingsButton Method - Loads the settings scene when the "SETTINGS" button is pressed
    public void SettingsButton() {

        SceneTracker.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex; //Store the current scene index before loading the settings scene
        StartCoroutine(LoadSceneWithSFX(1));

    } //End of SettingsButton Method

    //QuitGameButton Method - Quits the game when the "QUIT GAME" button is pressed
    public void QuitGameButton() { 
        Debug.Log("Closing Application");
        Application.Quit(); 
    }


    private IEnumerator LoadSceneWithSFX(int sceneIndex)
    {
        if (clickSFX != null)
            clickSFX.Play();

        yield return new WaitForSeconds(0.50f);  // Delay so sound can play

        SceneManager.LoadSceneAsync(sceneIndex);
    }

} //End of MainMenuController Class
