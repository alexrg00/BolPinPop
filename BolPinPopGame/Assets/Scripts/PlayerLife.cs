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
    private FruitCollector fruitCollector; // Reference to the FruitCollector

    void Start()
{
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();  
    scoreManager = FindObjectOfType<ScoreManager>(); 
    fruitCollector = FindObjectOfType<FruitCollector>();
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
        
        if (fruitCollector != null)
        {
            fruitCollector.ResetBananaCount();
        }


        

        
        Invoke("RestartLevel", 2f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}