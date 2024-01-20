using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    private GameManager gameManager;

    private string saveFilePath;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();

        saveFilePath = Application.persistentDataPath + "/gamedata.data";
    }

    public void SaveIntoJson()
    {
        GameData _resourcesData = new GameData(Load());

        string data = JsonUtility.ToJson(_resourcesData, true);

        File.WriteAllText(saveFilePath, data);
    }

    public GameData Load()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            return gameData;
        }
        else return null;
    }

    public void DeleteSave()
    {
        File.Delete(saveFilePath);
    }
}

[System.Serializable]
public class GameData
{
    public List<PlayerScore> HallOfFame = new List<PlayerScore>();

    public GameData(GameData oldData)
    {
        if (oldData != null)
        {
            foreach (PlayerScore pScore in oldData.HallOfFame)
            {
                HallOfFame.Add(pScore);
            }
        }

        HallOfFame.Add(new PlayerScore());
    }

    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public string playerTime;
        public float playerScore;

        public PlayerScore()
        {
            GameManager gameManager = SaveManager.FindObjectOfType<GameManager>();

            playerName = gameManager.CurrentPlayerName;
            playerTime = gameManager.GetCurrentTime();
            playerScore = gameManager.Score;
        }
    }
}
