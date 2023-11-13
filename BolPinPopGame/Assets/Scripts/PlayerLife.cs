using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    private ScoreManager scoreManager; // Reference to the ScoreManager

    void Start()
{
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();  // Fix here
    scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Reset the player's score on death
        if (scoreManager != null)
        {
            scoreManager.ResetScoreOnDeath();
        }

        // You can add other death-related logic here

        // Restart the level after a delay (example: 2 seconds)
        Invoke("RestartLevel", 2f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}