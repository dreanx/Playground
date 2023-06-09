using UnityEngine;
// Script attached to the Player
// PuRef = Empty
// PrRef = float moveSpeed

public class Player : MonoBehaviour
{
    private float moveSpeed = 5f; // Speed at which the player moves

    public void Update()
    {
        Vector2 inputVector = new Vector2(0, 0); // Initialize the input vector

        if (Input.GetKey(KeyCode.Z)) // Check if the 'Z' key is pressed
        {
            inputVector.y += 1; // Increase the y component of the input vector
        }

        if (Input.GetKey(KeyCode.S)) // Check if the 'S' key is pressed
        {
            inputVector.y -= 1; // Decrease the y component of the input vector
        }

        if (Input.GetKey(KeyCode.D)) // Check if the 'D' key is pressed
        {
            inputVector.x += 1; // Increase the x component of the input vector
        }

        if (Input.GetKey(KeyCode.Q)) // Check if the 'Q' key is pressed
        {
            inputVector.x -= 1; // Decrease the x component of the input vector
        }

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); // Create a movement direction vector
        inputVector = inputVector.normalized; // Normalize the input vector to ensure consistent speed in all directions

        transform.position += moveSpeed * Time.deltaTime * moveDir; // Move the player in the calculated direction at a constant speed
    }
}