using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created Date: October 22, 2025
 * Created By: Abraar Sadek
 * Purpose: This class is responsible for controlling the pause panel UI in the game.
 */

//PausePanelController Class - Manages the pause panel UI
public class PausePanelController : MonoBehaviour {

    [Header("Pause Panel UI")]
    public GameObject pausePanel;

    private bool isPaused = false;

    //Start Method - Called before the first frame update
    void Start() {

        Time.timeScale = 1f; //Set the time scale to 1 at the start of the game
        pausePanel.SetActive(false); //Ensure the pause panel is hidden at the start of the run

    } //End of Start Method

    //Update Method - Called once per frame
    void Update() {

        //If-Statement - Check for Escape key press to toggle pause state
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {

            //Nested If-Else Statement - Toggle between pausing and resuming the game
            if (isPaused) {
                ResumeGame(); //Call Method
            } else {
                PauseGame(); //Call Method
            } //End of Nested If-Else Statement

        } //End of If-Statement

    } //End of Update Method

    //PauseGame Method - Pauses the game when the Escape key button is pressed
    public void PauseGame() {

        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        pausePanel.SetActive(true);
        isPaused = true;
        Debug.Log("Game Paused");

    } //End of PauseGame Method

    //ResumeGame Method - Unpauses the game when the "RESUME GAME" button or Escape key is pressed
    public void ResumeGame() {

        Time.timeScale = 1f; //Resume the game by setting time scale back to 1
        pausePanel.SetActive(false);
        isPaused = false;
        Debug.Log("Game Resumed");

    } //End of ResumeGame Method

    //QuitGame Method - Loads the main menu scene when the "QUIT GAME" button is pressed
    public void QuitGame() {

        Debug.Log("Quitting Game..."); //Log quitting message
        SceneManager.LoadSceneAsync(0); //Load Main Menu Scene

    } //End of QuitGame Method

} //End of PauseMenu Class
