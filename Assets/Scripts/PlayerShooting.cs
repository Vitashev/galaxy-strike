using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject[] lazerParticles; // Assign your bullet prefabs in the Inspector
    [SerializeField] RectTransform cursor;

    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // Keeps the cursor within the game window
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLazerEmission();
        UpdateCursorPosition();
    }

    private void UpdateCursorPosition()
    {
        if (cursor != null)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            cursor.position = mousePosition;
        }
        else
        {
            Debug.LogWarning("Cursor RectTransform is not assigned.");
        }
    }

    private void UpdateLazerEmission()
    {
        foreach (GameObject lazer in lazerParticles)
        {
            ParticleSystem ps = lazer.GetComponent<ParticleSystem>();
            ParticleSystem.EmissionModule emission = ps.emission;
            emission.enabled = isShooting;
        }
    }

    public void OnFire(InputValue context)
    {
        isShooting = context.isPressed;
    }
}
