using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Toggle godModeToggle;

    private BlockManager blockManager;
    private UIManager uiManager;

    public float Score { get; private set; }

    private void Awake()
    {
        blockManager = GetComponent<BlockManager>();
        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        uiManager.SetScoreText(Score);
    }

    private void Update()
    {
        uiManager.SetTimerText(Time.timeSinceLevelLoad);
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene(0);
    }

    public void SetGodMode()
    {
        FindObjectOfType<Player>().SetGodMode(godModeToggle.isOn);
    }

    public void AddScore(float value, Transform startPosition)
    {
        Score += value;
        uiManager.SetScoreText(Score);
        uiManager.ScorePopUp(value, startPosition);
    }
}
