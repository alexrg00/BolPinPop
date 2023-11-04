using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float floatForce = 10.0f; // The force that pushes the balloon up
    public float maxY = 5.0f; // The maximum height for the balloon
    public float minY = 1.0f; // The minimum height for the balloon

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Apply an initial upward force to the balloon
        rb.AddForce(Vector2.up * floatForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        Vector2 position = rb.position;

        // Check if the balloon is at the maximum height and reverse its direction
        if (position.y >= maxY)
        {
            rb.velocity = Vector2.down * floatForce;
        }

        // Check if the balloon is at the minimum height and reverse its direction
        if (position.y <= minY)
        {
            rb.velocity = Vector2.up * floatForce;
        }
    }
}
