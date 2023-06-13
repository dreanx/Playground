using Unity.Mathematics;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f; //Smooth rotation of Player
    private float turnSmoothVelocity;

    private void Update()
    {
        // (MOVE)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // (ROTATE & MOVE) If the length of our direction vector is positive
        if (direction.magnitude > 0.1f)
        {
            // (ROTATE) rotation towards direction vector
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // Add the rotation of the camera of the Y axis on top of our angle. the Atan2 returns an angle (between 0 and target angle) in radians that we convert into degrees
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //Smooth the turn of the Player
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // (MOVE)
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle,0f) * Vector3.forward; // Turning the rotation of the camera into a direction
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}