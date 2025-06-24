using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit by a particle!");
        Instantiate(explosionEffect, transform.position, Quaternion.identity); // Spawn the explosion effect
        Destroy(gameObject); // Destroy the enemy when hit by a particle
        Debug.Log("Trigger detected with: " + other.gameObject.name);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
