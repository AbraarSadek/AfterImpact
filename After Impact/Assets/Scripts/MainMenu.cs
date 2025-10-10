using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    
    public void Settings()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void TheMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
