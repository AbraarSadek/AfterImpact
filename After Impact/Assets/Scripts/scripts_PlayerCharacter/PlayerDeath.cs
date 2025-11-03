using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Created Date: 10/30/2025
 * Created By: Drew Oro
 * Purpose: This script is responsible for handling PlayerDeath from the collision with the meteorites.
 */

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Meteorite"))
        {
            stopGame();
        }
    }
    IEnumerator stopGame()
    {
        //Death Animation
        yield return new WaitForSeconds(2);
        Time.timeScale = 0.0f;
        SceneManager.LoadSceneAsync(3);
    }
}
