using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;  // Reference to the CharacterController component
    public float speed = 12f;  // Speed at which the player moves
    public float gravity = -9.81f;  // Gravity value affecting the player's vertical movement
    public float jumpHeight = 3f;  // Height the player can jump

    public Transform groundCheck;  // Reference to a transform representing the ground check position
    public float groundDistance = 0.4f;  // Distance to check for ground detection
    public LayerMask groundMask;  // Layer mask to determine what is considered as ground

    private Vector3 velocity;  // Current velocity of the player
    private bool isGrounded;  // Flag to indicate if the player is grounded

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the player is grounded and the velocity is negative, set it to a small value to ensure the player sticks to the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input values for horizontal and vertical movement
        float x = Input.GetAxis("Horizontal");  // Get input value for horizontal movement (left/right)
        float z = Input.GetAxis("Vertical");  // Get input value for vertical movement (forward/backward)

        // Calculate the movement vector based on input values and player's orientation
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the character controller based on the calculated movement vector and speed
        characterController.Move(move * speed * Time.deltaTime);

        // Check if the Jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Calculate the vertical velocity to perform a jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply gravity to the vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // Move the character controller based on the velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
