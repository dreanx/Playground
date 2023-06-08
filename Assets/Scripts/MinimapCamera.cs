using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPos = player.transform.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
