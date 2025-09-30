using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;  // ❗ Corrected casing (was RigidBody2D)
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ❗ Corrected casing
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed); // ❗ Removed incorrect dot
    }
}
