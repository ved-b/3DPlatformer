using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform cameraTransform;
    private int jumpCount = 1;
    [SerializeField] private int maxJumpCount = 2;

    private bool dashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    void Update()
    {
        // Reset jump counter when the player is grounded.
        if (IsGrounded())
        {
            jumpCount = 1;
        }
        
        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        // Determine movement direction based on W, A, S, D keys.
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

        // Jump & Double Jump: allow jump if jumpCount is below the maxJumpCount.
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            jumpCount++;
            Vector3 jump = new Vector3(0, jumpForce, 0);
            GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashing && !IsGrounded()) 
        {
            StartCoroutine(Dash(forward));
        }

        // Move the player.
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // Checks if the player is grounded based on the collider's extents plus a small buffer.
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.05f);
    }

    private IEnumerator Dash(Vector3 forward) {
        dashing = true;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(forward.x * dashingPower, 0, forward.z * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(dashingCooldown);
        dashing = false;
    }
}
