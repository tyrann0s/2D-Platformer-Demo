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
    private SaveManager saveManager;

    public float Score { get; private set; }
    private int comboMod = 1;

    public string CurrentPlayerName { get; set; }

    [SerializeField]
    private float comboTime;

    private bool isPlayerDead = false;

    private IEnumerator comboTimer;

    private void Awake()
    {
        blockManager = GetComponent<BlockManager>();
        uiManager = GetComponent<UIManager>();
        saveManager = GetComponent<SaveManager>();
    }

    private void Start()
    {
        uiManager.SetComboModText(1);
        comboTimer = ActiveCombo();
    }

    private void Update()
    {
        if (!isPlayerDead) uiManager.SetTimerText(Time.timeSinceLevelLoad);
    }

    public string GetCurrentTime() { return uiManager.GetTimerText(); }

    public void PlayerDied()
    {
        isPlayerDead = true;
        uiManager.ShowEnterNamePanel();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SetGodMode()
    {
        FindObjectOfType<Player>().SetGodMode(godModeToggle.isOn);
    }

    public void AddScore(float value, Transform startPosition)
    {
        StopCoroutine(comboTimer);

        value *= comboMod;
        Score += value;
        uiManager.ScorePopUp(value, startPosition);

        comboMod += 1;
        uiManager.SetComboModText(comboMod);

        comboTimer = ActiveCombo();
        StartCoroutine(comboTimer);
    }

    private IEnumerator ActiveCombo()
    {
        while (comboMod > 1)
        {
            yield return new WaitForSeconds(comboTime);

            comboMod -= 1;
            uiManager.SetComboModText(comboMod);
        }
    }

    public void SaveData() 
    {
        saveManager.SaveIntoJson(); 
    }
    public List<GameData.PlayerScore> LoadHOFPlayerScores() { return saveManager.Load().HallOfFame; }
}
