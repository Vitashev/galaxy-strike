using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect; // Speed of the enemy movement
    [SerializeField] int health = 3; // Health of the enemy
    [SerializeField] int scoreValue = 10; // Score value when the enemy is destroyed

    private ScoreBoard scoreBoard; // Reference to the ScoreBoard script
    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>(); // Find the ScoreBoard in the scene
        if (scoreBoard == null)
        {
            Debug.LogError("ScoreBoard not found in the scene!");
        }
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Enemy hit by a particle!");
        health--; // Decrease health by 1 when hit by a particle
        if (health <= 0)
        {
            scoreBoard.IncreaseScore(scoreValue); // Increase score when the enemy is destroyed
            DestroyEnemy();
        }


    }

    private void DestroyEnemy()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity); // Spawn the explosion effect
        Destroy(gameObject); // Destroy the enemy when hit by a particle
    }


}
