using UnityEngine;

public class PlayerJumpSystem : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 5f;
    private bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }

    public void Jump()
    {
        if (!isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}