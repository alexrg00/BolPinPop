using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private Animator anim; 

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on the "Bullet" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            anim.Play("Pop");
            Destroy(gameObject, 0.5f);
        }
    }
}
