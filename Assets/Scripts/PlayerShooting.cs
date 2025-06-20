using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject[] lazerParticles; // Assign your bullet prefabs in the Inspector
    [SerializeField] RectTransform cursor;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f; // Distance from the camera to the target point

    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Confined; // Keeps the cursor within the game window
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLazerEmission();
        UpdateCursorPosition();
        UpdateTargetPointPosition();
        DirectShootingToTargetPoint();
    }

    private void UpdateTargetPointPosition()
    {
        if (targetPoint != null)
        {
            // Use the new Input System to get the mouse position
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector3 targetPointPosition = new Vector3(mousePosition.x, mousePosition.y, targetDistance);

            targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
        }
        else
        {
            Debug.LogWarning("Target Point Transform is not assigned.");
        }
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

    private void DirectShootingToTargetPoint()
    {
        // direct lazer particles towards the target point
        if (targetPoint != null)
        {

            foreach (GameObject lazer in lazerParticles)
            {
                Vector3 direction = (targetPoint.position - this.transform.position).normalized;
                lazer.transform.rotation = Quaternion.LookRotation(direction);

                // Optionally, you can also set the position of the lazer particles to the target point
                // lazer.transform.position = targetPoint.position;
            }
        }
        else
        {
            Debug.LogWarning("Target Point Transform is not assigned.");
        }
    }
}
