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

    private void Awake()
    {
        blockManager = GetComponent<BlockManager>();
        uiManager = GetComponent<UIManager>();
        saveManager = GetComponent<SaveManager>();
    }

    private void Start()
    {
        uiManager.SetComboModText(1);
    }

    private void Update()
    {
        uiManager.SetTimerText(Time.timeSinceLevelLoad);
    }

    public void PlayerDied()
    {
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
        value *= comboMod;
        Score += value;
        uiManager.ScorePopUp(value, startPosition);

        StartCoroutine(ActiveCombo());
    }

    private IEnumerator ActiveCombo()
    {
        comboMod += 1;
        uiManager.SetComboModText(comboMod);

        yield return new WaitForSeconds(comboTime);

        comboMod -= 1;
        uiManager.SetComboModText(comboMod);
    }

    public void SaveData() 
    {
        saveManager.SaveIntoJson(); 
    }
    public List<GameData.PlayerScore> LoadHOFPlayerScores() { return saveManager.Load().HallOfFame; }
}
