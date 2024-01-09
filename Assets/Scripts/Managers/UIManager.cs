using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, timerText, comboText;

    [SerializeField]
    private GameObject scoreTextPrefab;

    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private HOF_EnterName enterNamePanel;
    [SerializeField]
    private HOF_LeaderBoard leaderBoardPanel;

    public void SetTimerText(float time)
    {
        timerText.text = string.Format("{0:00}:{1:00}", TimeSpan.FromSeconds(time).Minutes, TimeSpan.FromSeconds(time).Seconds);
    }

    public void SetScoreText(float value)
    {
        scoreText.text = value.ToString();
    }

    public void SetComboModText(int value)
    {
        comboText.text = "x" + value.ToString();
    }

    public void ScorePopUp(float value, Transform startPosition)
    {
        GameObject go = Instantiate(scoreTextPrefab, ui.transform);
        go.transform.position = startPosition.position;
        TMP_Text goText = go.GetComponentInChildren<TMP_Text>();
        goText.text = value.ToString();

        Vector3 upPos = new Vector3(startPosition.position.x, startPosition.position.y + .5f);
        go.GetComponent<ScoreText>().Init(scoreText.gameObject, upPos);
    }

    public void ShowEnterNamePanel()
    {
        enterNamePanel.gameObject.SetActive(true);
    }

    public void ShowLeaderBoardPanel()
    {
        leaderBoardPanel.gameObject.SetActive(true);
        leaderBoardPanel.AddName();
    }
}
