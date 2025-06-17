using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // You can adjust this speed in the Inspector
    [SerializeField] private float clampX = 1f;    // Max X movement per frame
    [SerializeField] private float clampY = 1f;    // Max Y movement per frame
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: You can initialize things here if needed
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleRotation()
    {
        float tiltAmount = 20f; // Max tilt angle in degrees
        float tiltX = -moveInput.y * tiltAmount;
        float tiltZ = -moveInput.x * tiltAmount;

        Quaternion targetRotation = Quaternion.Euler(tiltX, 0f, tiltZ);
        float smooth = 5f; // Increase for snappier, decrease for heavier
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }

    private void HandleMovement()
    {
        // Calculate the movement vector
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        // Update the player's local position directly
        Vector3 newPos = transform.localPosition + movement;
        // Clamp the new position within the allowed area
        newPos.x = Mathf.Clamp(newPos.x, -clampX, clampX);
        newPos.y = Mathf.Clamp(newPos.y, -clampY, clampY);
        transform.localPosition = newPos;
    }

    public void OnMove(InputValue context)
    {
        // Get the Vector2 input from the InputValue
        moveInput = context.Get<Vector2>();
    }
}
