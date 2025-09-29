using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float baseMoveSpeed = 10f;
    public float baseJumpForce = 20f;
    public float size = 1f;

    private PlayerMovementSystem movement;
    private PlayerJumpSystem jump;

    private float originalMoveSpeed;
    private float originalJumpForce;
    private float originalSize;

    private void Awake()
    {
        movement = GetComponent<PlayerMovementSystem>();
        jump = GetComponent<PlayerJumpSystem>();

        originalMoveSpeed = baseMoveSpeed;
        originalJumpForce = baseJumpForce;
        originalSize = size;

        ApplyStats();
    }

    private void ApplyStats()
    {
        if (movement != null)
            movement.moveSpeed = baseMoveSpeed;

        if (jump != null)
            jump.jumpForce = baseJumpForce;

        transform.localScale = Vector3.one * size;
    }

    public void ModifyMoveSpeed(float newSpeed)
    {
        baseMoveSpeed = newSpeed;
        ApplyStats();
    }

    public void ModifyJumpForce(float newForce)
    {
        baseJumpForce = newForce;
        ApplyStats();
    }

    public void ModifySize(float newSize)
    {
        size = newSize;
        ApplyStats();
    }

    public void ResetMoveSpeed()
    {
        baseMoveSpeed = originalMoveSpeed;
        ApplyStats();
    }

    public void ResetJumpForce()
    {
        baseJumpForce = originalJumpForce;
        ApplyStats();
    }

    public void ResetSize()
    {
        size = originalSize;
        ApplyStats();
    }
}
