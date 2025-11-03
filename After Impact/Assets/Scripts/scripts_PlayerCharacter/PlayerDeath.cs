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
            Debug.Log("Hit");
            StartCoroutine(stopGame());
        }
    }
    static IEnumerator stopGame()
    {
        //Death Animation
        Debug.Log("StopGame");
        yield return new WaitForSeconds(2);
        Debug.Log("Waited 2 seconds");
        Time.timeScale = 0.0f;
        SceneManager.LoadSceneAsync(3);
    }
}
