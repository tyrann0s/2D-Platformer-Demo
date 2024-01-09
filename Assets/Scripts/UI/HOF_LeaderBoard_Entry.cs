using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HOF_LeaderBoard_Entry : MonoBehaviour
{
    [SerializeField]
    private Text placeText, nameText, scoreText;
    public int Score => int.Parse(scoreText.text);
    public void SetUp(int place, string playerName, string score)
    {
        placeText.text = place.ToString();
        nameText.text = playerName;
        scoreText.text = score;
    }
}
