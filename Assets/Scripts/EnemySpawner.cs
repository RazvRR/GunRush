using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTransform;      // Assign the player's transform
    public GameObject enemyPrefab;         // Assign the enemy prefab
    public int numberOfEnemies = 5;        // Number of enemies to spawn
    public float spawnRadius = 5f; 
    
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Generate a random point inside a circle
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

            // Calculate the spawn position
            Vector2 spawnPosition = (Vector2)playerTransform.position + randomOffset;

            // Instantiate the enemy
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
