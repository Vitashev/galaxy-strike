using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect; // Speed of the enemy movement
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Enemy hit by a particle!");
        Instantiate(explosionEffect, transform.position, Quaternion.identity); // Spawn the explosion effect
        Destroy(gameObject); // Destroy the enemy when hit by a particle

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
