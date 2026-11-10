using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

/// <summary>
/// 移動、ジャンプ処理
/// </summary>
public class PlayerMovement
{
    private CharacterController CharacterController;
    private PlayerStatus PlayerStatus;
    private PlayerInputHandle PlayerInputHandle;


    public PlayerMovement(CharacterController characterController, PlayerStatus playerStatus, PlayerInputHandle playerInputHandle)
    {
        CharacterController = characterController;
        PlayerStatus = playerStatus;
        PlayerInputHandle = playerInputHandle;
    }
    public void Move(PlayerInput PlayerInput ,Transform transform)
    {
        Vector3 move = Vector3.forward * PlayerStatus.MoveSpeed;
        move = Vector3.right * PlayerInputHandle.MoveInput.x * PlayerStatus.MoveSpeed;
        //move += Vector3.right * PlayerInputHandle.MoveInput.x * PlayerStatus.MoveSpeed;(前進)
        
        CharacterController.Move(move * Time.deltaTime);

    }
    public void Gravity()
    {
        if (CharacterController.isGrounded && PlayerStatus.Velocity.y < 0)
        {
            PlayerStatus.Velocity.y = -2f;
            
        }

        PlayerStatus.Velocity.y += PlayerStatus.Gravity * Time.deltaTime;
        CharacterController.Move(PlayerStatus.Velocity * Time.deltaTime);
    }
}
