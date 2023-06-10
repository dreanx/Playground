using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;  // Reference to the CharacterController component
    public float speed = 12f;  // Speed at which the player moves

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");  // Get input value for horizontal movement (left/right)
        float z = Input.GetAxis("Vertical");  // Get input value for vertical movement (forward/backward)

        Debug.Log("X: " + x + "Y: " + z);  // Output the current input values to the console

        Vector3 move = transform.right * x + transform.forward * z;  // Calculate the movement vector

        characterController.Move(move * speed * Time.deltaTime);  // Move the character based on the calculated movement vector
    }
}