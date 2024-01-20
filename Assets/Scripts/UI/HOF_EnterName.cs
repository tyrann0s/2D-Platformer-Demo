using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HOF_EnterName : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText;

    [SerializeField]
    private Button acceptButton, restartButton;

    private GameManager gameManager;
    private UIManager uiManager;

    private void Start()
    {
        acceptButton.onClick.AddListener(Proceed);
        restartButton.onClick.AddListener(Restart);
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Proceed()
    {
        uiManager.PlayButtonClickSound();

        if (IsPlayerNameViable())
        {
            gameManager.CurrentPlayerName = playerNameText.text;
            uiManager.ShowLeaderBoardPanel();
            gameObject.SetActive(false);
        }
        else ShakeWindow();
    }

    private bool IsPlayerNameViable()
    {
        if (playerNameText.text == "") return false;
        if (!playerNameText.text.All(Char.IsLetterOrDigit)) return false;

        return true;
    }

    private void ShakeWindow()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        DOTween.Sequence(rectTransform.DOPunchPosition(Vector3.left * 5, 1f)).
            Append(rectTransform.DOPunchPosition(-Vector3.left * 5, 1f));
    }

    private void Restart()
    {
        gameManager.ReloadScene();
    }
}
