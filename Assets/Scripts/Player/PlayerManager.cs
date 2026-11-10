using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(CharacterController))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]private PlayerStatus Status;
    public PlayerInputHandle Input { get; private set; }
    public PlayerMovement Movement { get; private set; }


    PlayerInput PlayerInput;
    CharacterController CharacterController;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
        CharacterController = GetComponent<CharacterController>();


        Input = new PlayerInputHandle(PlayerInput);
        Movement = new PlayerMovement(CharacterController, Status, Input);
    }
    void Start()
    {
        Input.EnableInput();
    }

    private void OnDestroy()
    {
        Input?.DisableInput();
    }

    // Update is called once per frame
    void Update()
    {
        Movement.Move(PlayerInput, transform);
        //Movement.Gravity();
    }
}
