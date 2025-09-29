using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private PlayerMovementSystem movementSystem;
    private PlayerJumpSystem jumpSystem;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        movementSystem = GetComponent<PlayerMovementSystem>();
        jumpSystem = GetComponent<PlayerJumpSystem>();
    }

    private void FixedUpdate()
    {
        movementSystem.Move(inputHandler.MoveInput);

        if (inputHandler.JumpTriggered)
        {
            jumpSystem.Jump();
            inputHandler.ResetJump();
        }
    }
}