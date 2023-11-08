using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Balloon : MonoBehaviour
{
    private Animator anim; // Rename the variable to "animator"
    private ScoreManager scoreManager;

    void Start()
    {
        anim = GetComponent<Animator>(); // Corrected variable name here
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            anim.Play("Pop");
            Destroy(gameObject, 0.5f);

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(5);
            }
        }
    }
}