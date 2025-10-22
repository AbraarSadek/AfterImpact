using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = transform.position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
