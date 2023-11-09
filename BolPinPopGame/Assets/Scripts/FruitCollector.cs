using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollector : MonoBehaviour
{
    private ScoreManager scoreManager;
    private int bananaCount = 0; // New variable to track the number of bananas collected
    [SerializeField] private Text BananaTxt;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        UpdateBananaCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionSoundEffect.Play();
            // Increase the banana count by 1 when the player picks up a banana
            bananaCount++;
            UpdateBananaCountText();

            // Increase the score by 1 when the player picks up a banana
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(1);
            }

            // Handle banana collection and destroy the banana
            Destroy(collision.gameObject);
        }
    }

    private void UpdateBananaCountText()
    {
        // Update the UI Text element to display the banana count
        BananaTxt.text = "Bananas: " + bananaCount;
    }
}