using UnityEngine;
using UnityEngine.InputSystem;

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
        Vector3 cameraforward = PlayerInput.camera.transform.forward;
        cameraforward.y = 0;
        cameraforward.Normalize();
        Vector3 cameraRight = PlayerInput.camera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();
        Vector3 direction = PlayerInputHandle.MoveInput.x * cameraRight + PlayerInputHandle.MoveInput.y * cameraforward;
        direction = Vector3.ClampMagnitude(direction, 1f);

        CharacterController.Move(direction * PlayerStatus.MoveSpeed * Time.deltaTime);

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = transform.forward;
            transform.up = Vector3.up;
            transform.forward = Vector3.Slerp(forward, direction, PlayerStatus.RotateSpeed * Time.fixedDeltaTime);
        }
        
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
