using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;  // The player's score
    [SerializeField] private Text ScoreTxt; // Reference to the UI Text element to display the score

    // Use this method to increase the player's score
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the UI text element to display the current score
    private void UpdateScoreText()
    {
        if (ScoreTxt != null)
        {
            ScoreTxt.text = "Score:" + score.ToString();
        }
    }
}
