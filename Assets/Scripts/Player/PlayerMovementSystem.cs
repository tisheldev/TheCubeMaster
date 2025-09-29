using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    public Transform orientation;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    private Vector2 input;

    void Start()
    {
        rb.freezeRotation = true;
    }

    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Move(input);
    }

    public void Move(Vector2 input)
    {
        Vector3 moveDir = orientation.forward * input.y + orientation.right * input.x;
        moveDir.y = 0f;
        moveDir.Normalize();
        Vector3 currentVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        Vector3 targetVel = moveDir * moveSpeed;
        Vector3 newVel = Vector3.Lerp(currentVel, targetVel, acceleration * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(newVel.x, rb.linearVelocity.y, newVel.z);
    }
}