using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveSpeed = 5f;
    
    public void Update()
    {

        Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.Z))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            inputVector.x -= 1;
        }

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        inputVector = inputVector.normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
