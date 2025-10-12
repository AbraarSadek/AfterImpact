using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float minY = 0f;
    public float maxY = 9f;

    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);

        // Clamp the player's Y position
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
