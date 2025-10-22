using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    public void EndGame()
    {
        SceneManager.LoadSceneAsync(3);
    }

}
