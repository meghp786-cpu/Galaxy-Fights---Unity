using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreUI;
    private int score;
    public void AddScore(int amount)
    {
        score += amount;
        ScoreUI.text = score.ToString();
    }
}
