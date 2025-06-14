using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // You can adjust this speed in the Inspector
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: You can initialize things here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement vector
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;

        // Apply the movement to the player's position
        transform.Translate(movement);
    }

    public void OnMove(InputValue context)
    {
        // Get the Vector2 input from the InputValue
        moveInput = context.Get<Vector2>();
    }
}
