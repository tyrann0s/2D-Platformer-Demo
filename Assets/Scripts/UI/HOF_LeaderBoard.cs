using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HOF_LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject leaderBoard_Entry_Prefab;

    [SerializeField]
    private Transform tableTransform;

    [SerializeField]
    private Button restartButton;

    private GameManager gameManager;

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void AddName()
    {
        gameManager.SaveData();

        List<GameData.PlayerScore> orderedList = gameManager.LoadHOFPlayerScores().OrderByDescending(x => x.playerScore).ToList();

        int place = 1;
        foreach (GameData.PlayerScore pScore in orderedList)
        {
            GameObject go = Instantiate(leaderBoard_Entry_Prefab, tableTransform);
            go.GetComponent<HOF_LeaderBoard_Entry>().SetUp(place, pScore.playerName, pScore.playerTime, pScore.playerScore.ToString());
            place++;

            if (place >= 11) break;
        }
    }

    private void Restart()
    {
        FindObjectOfType<UIManager>().PlayButtonClickSound();
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
