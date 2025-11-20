using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created Date: October 22, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for controlling the game over menu UI interactions.
 * 
 * V1 
 * Modified Date: November 11, 2025
 * Modifed By: Drew Oro
 * Purpose: Inputting the current score and high score in the UI
 */

//GameOverMenuController Class - Used to control the game over menu UI
public class GameOverMenuController : MonoBehaviour {

    [SerializeField] private AudioSource clickSFX;

    //PlayAgainButton Method - Loads the level scene when the "PLAY AGAIN" button is pressed
    public void PlayAgainButton()
    {
        StartCoroutine(LoadSceneWithSFX(2));
    }
  


    //SettingsButton Method - Loads the settings scene when the "SETTINGS" button is pressed
    public void SettingsButton() 
    {

        SceneTracker.PreviousSceneIndex = SceneManager.GetActiveScene().buildIndex; //Store the current scene index before loading the settings scene
        StartCoroutine(LoadSceneWithSFX(1));

    } //End of SettingsButton Method

    //QuitGameButton Method - Loads the main menu scene when the "QUIT GAME" button is pressed
    public void QuitGameButton() 
    {
        StartCoroutine(LoadSceneWithSFX(0));
    }

    private IEnumerator LoadSceneWithSFX(int sceneIndex)
    {
        if (clickSFX != null)
            clickSFX.Play();

        yield return new WaitForSeconds(0.50f);  // Delay so sound can play

        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public GameObject text_Score;
    public GameObject text_HighScore;
    private void Start()
    {
        DataManager.LoadData();

        int score = ((int)ScoreManager.currentScore);
        int highScore = ((int)ScoreManager.highScore);
        text_Score.GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();
        if (score >= highScore)
        {
            ScoreManager.highScore = highScore;
            DataManager.SaveData();
            text_HighScore.GetComponent<TextMeshProUGUI>().text = "HIGH SCORE: " + score.ToString();
        }
        else {
            text_HighScore.GetComponent<TextMeshProUGUI>().text = "HIGH SCORE: " + highScore.ToString();
        }
        //Resets score
        ScoreManager.currentScore = 0;

    }

} //End of GameOverMenuController Class
