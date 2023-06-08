using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetCamera = new Vector3(0,2,-5);


        private void Update()
    {
        transform.position = player.transform.position + offsetCamera;
    }
}