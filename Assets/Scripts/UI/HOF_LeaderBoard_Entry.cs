using UnityEngine;
using UnityEngine.UI;

public class HOF_LeaderBoard_Entry : MonoBehaviour
{
    [SerializeField]
    private Text placeText, nameText, timeText, scoreText;
    public int Score => int.Parse(scoreText.text);

    public void SetUp(int place, string playerName, string time, string score)
    {
        placeText.text = place.ToString();
        nameText.text = playerName;
        timeText.text = time;
        scoreText.text = score;
    }
}
