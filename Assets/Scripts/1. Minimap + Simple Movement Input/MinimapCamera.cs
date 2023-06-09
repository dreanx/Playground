using UnityEngine;

// Script attached to Minimap Camera (changed into a material renderer)
// PuRef = Transform player
// PrRef = ***

public class MinimapCamera : MonoBehaviour
{
    public Transform player; // Reference to the player object's transform

    private void LateUpdate()
    {
        Vector3 newPos = player.transform.position; // Get the current position of the player
        newPos.y = transform.position.y; // Keep the same Y position as the minimap camera
        transform.position = newPos; // Set the new position of the minimap camera
    }
}