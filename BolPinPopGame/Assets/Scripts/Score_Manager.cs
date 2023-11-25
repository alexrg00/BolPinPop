using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject nextLevelButton;
    private int pointsGainedInCurrentLevel = 0;

    private void Start()
    {
        // Load the score from PlayerPrefs
        score = PlayerPrefs.GetInt("PlayerScore", 0);
        UpdateScoreText();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActivateNextLevelButton();
        }
    }


    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Update points gained in the current level
        pointsGainedInCurrentLevel += points;

        // Check if the player should transition to the next level
        if (pointsGainedInCurrentLevel >= 15)
        {
            ActivateNextLevelButton();
        }
    }

    private void ActivateNextLevelButton()
    {

        if (nextLevelButton != null)
        {
            nextLevelButton.SetActive(true);
        }
    }

    public void OnNextLevelButtonClick()
    {
        SwitchToNextLevel();
    }

    public void ResetScoreOnDeath()
    {
        // Reset the player's score to 0
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.Save();

        // Update the score variable
        score = 0;
        UpdateScoreText();

        // Reset points gained in the current level
        pointsGainedInCurrentLevel = 0;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText is null");
        }
    }

    private void SwitchToNextLevel()
    {
        // Save the current score before switching scenes
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

        // Reset points gained in the current level
        pointsGainedInCurrentLevel = 0;

        // Load the next level based on the build index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}