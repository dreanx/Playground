using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player object's transform
    public Vector3 offsetCamera = new Vector3(0, 2, -5); // Offset to adjust the camera position relative to the player

    private void Update()
    {
        // Set the position of the camera to the player's position plus the offset
        transform.position = player.transform.position + offsetCamera;
    }
}