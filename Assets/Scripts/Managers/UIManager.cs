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
    private Text scoreText, timerText;

    [SerializeField]
    private GameObject scoreTextPrefab;

    [SerializeField]
    private GameObject ui;

    public void SetTimerText(float time)
    {
        timerText.text = string.Format("{0:00}:{1:00}", TimeSpan.FromSeconds(time).Minutes, TimeSpan.FromSeconds(time).Seconds);
    }

    public void SetScoreText(float value)
    {
        scoreText.text = value.ToString();
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
}
