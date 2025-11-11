using UnityEngine;
using System.IO;

/*
 * Created Date: November 11, 2025
 * Created By: Drew Oro
 * Purpose: This script is responsible for saving data and loading data.
*/

public class DataManager : MonoBehaviour
{
   public class PlayerData
    {
        public float score;
    }
    private static string filePath = Application.persistentDataPath + "/playerdata.json";
  public static void SaveData()
    {
       PlayerData data = new PlayerData();
       data.score = ScoreManager.currentScore;
        string JSONfile = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, JSONfile);
    }
public static void LoadData()
    {
        if (File.Exists(filePath))
        {
            string JSONfile = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(JSONfile);
            ScoreManager.highScore = ((int)data.score);
        }
        else
        {
            Debug.Log("Cannot Find Data!");
            ScoreManager.highScore = 0;
        }
    }
}
