using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        // Determine movement direction based on W, A, S, D
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= right;
        }

        // Move the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
}
