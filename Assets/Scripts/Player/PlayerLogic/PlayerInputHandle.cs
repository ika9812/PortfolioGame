using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 入力処理
/// </summary>
public class PlayerInputHandle
{
    PlayerInput PlayerInput;

    public Vector2 MoveInput;
    public PlayerInputHandle(PlayerInput playerInput)
    {
        PlayerInput = playerInput;
    }

    public void EnableInput()
    {
        PlayerInput.actions["Move"].performed += OnMove;
        PlayerInput.actions["Move"].canceled += OnMove;

    }
    public void DisableInput()
    {
        PlayerInput.actions["Move"].performed -= OnMove;
        PlayerInput.actions["Move"].canceled -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
  
}
