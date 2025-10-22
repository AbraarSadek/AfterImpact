using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public GameObject enemyPrefab;    // Assign in Inspector
    public Transform spawnPoint;      // Empty GameObject ahead of player (for X/Z)
    public float minY = -2f;          // Lower limit for Y
    public float maxY = 4f;           // Upper limit for Y

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            // Generate randomized Y position within allowed range
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPos = new Vector3(spawnPoint.position.x, randomY, spawnPoint.position.z);

            // Instantiate enemy with randomized Y, fixed X and Z
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
