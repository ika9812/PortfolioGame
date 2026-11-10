using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Scriptable Objects/PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    [Header("移動速度")] public float MoveSpeed = 10f;
    [Header("ジャンプの高さ")] public float JumpHeight = 2f;
    [Header("重力")] public float Gravity = -9.81f;
    [Header("速度")] public Vector2 Velocity;
    [Header("回転速度")] public float RotateSpeed = 5f;
    [Header("現在のスタミナ")] public float CurrentStamina = 100f;

}
