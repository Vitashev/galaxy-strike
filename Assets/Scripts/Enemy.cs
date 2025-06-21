using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
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
