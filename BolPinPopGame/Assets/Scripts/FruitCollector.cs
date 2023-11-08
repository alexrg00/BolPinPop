using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollector : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            // Increase the score by 1 when the player picks up a banana
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(1);
            }

            // Handle banana collection and destroy the banana
            Destroy(collision.gameObject);
        }
    }
}