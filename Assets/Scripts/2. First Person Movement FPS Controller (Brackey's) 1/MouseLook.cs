using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Sensitivity of the mouse movement
    public Transform playerBody;  // Reference to the player body transform

    private float xRotation = 0f;  // Current rotation around the x-axis (up and down)

    private float mouseX = 0;
    private float mouseY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Locks and hides the cursor
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // Get horizontal mouse movement
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // Get vertical mouse movement

        xRotation -= mouseY;  // Every frame we're going to decrease our x-rotation based on mouseY ; Adjust the xRotation by subtracting the vertical mouse movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Clamp the xRotation to ensure it stays between -90 and 90 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Apply rotation to the camera around the x-axis (up and down)
        playerBody.Rotate(Vector3.up * mouseX);  // Rotate the player body around the y-axis (left and right) based on horizontal mouse movement
    }
}