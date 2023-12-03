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

    private void Awake()
    {
        blockManager = GetComponent<BlockManager>();
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene(0);
    }

    public void SetGodMode()
    {
        FindObjectOfType<Player>().SetGodMode(godModeToggle.isOn);
    }
}
