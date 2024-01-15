using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using DG.Tweening;

public class HOF_EnterName : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText;

    [SerializeField]
    private Button acceptButton;

    private UIManager uiManager;

    private void Start()
    {
        acceptButton.onClick.AddListener(Proceed);
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Proceed()
    {
        uiManager.PlayButtonClickSound();

        if (IsPlayerNameViable())
        {
            FindObjectOfType<GameManager>().CurrentPlayerName = playerNameText.text;
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
}
