using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Balloon : MonoBehaviour
{
    private Animator anim; 
    private ScoreManager scoreManager;

    [SerializeField] private AudioSource popSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            popSoundEffect.Play();
            anim.Play("Pop");
            Destroy(gameObject, 0.05f);

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(5);
            }
        }
    }
}