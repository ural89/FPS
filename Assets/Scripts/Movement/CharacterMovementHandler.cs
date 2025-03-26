using UnityEngine;



public class CharactermovementHandler : MonoBehaviour
{

    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private MovementActionType currentActionType = MovementActionType.Standard;
    private PlayerData playerData;

    private CharacterController characterController;
    private IMovementAction movementAction;
    private Vector2 moveInput;
    private Vector3 moveDirection;
    private StandardMovementAction standardMovementAction;
    private RunMovementAction runMovementAction;

    private bool isRunning = false;
    private bool jump;

    public enum MovementActionType
    {
        Standard,
        Run
    }
    public void Construct(IPlayerDataContainer playerDataContainer)
    {
        playerData = playerDataContainer.GetPlayerData();
        standardMovementAction = new StandardMovementAction(playerData);
        runMovementAction = new RunMovementAction(playerData);
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        SetMovementAction(currentActionType);
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (characterController.isGrounded)
        {
            movementAction.Move(characterController, transform, moveInput);

            if (jump)
            {
                movementAction.HandleJump(ref moveDirection, playerData.GetJumpForce());
                jump = false;
            }
        }

        movementAction.ApplyGravity(ref moveDirection, gravity, Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void SetMovementAction(MovementActionType actionType)
    {
        switch (actionType)
        {
            default:
            case MovementActionType.Standard:
                movementAction = standardMovementAction;
                break;
            case MovementActionType.Run:
                movementAction = runMovementAction;
                break;
        }
    }

    public void SetMovementInput(Vector2 input)
    {
        moveInput = input;
    }

    public void SetJumpInput(bool shouldJump)
    {
        jump = shouldJump;
    }
    public void SetIsRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        if (isRunning)
        {
            SetMovementAction(MovementActionType.Run);
        }
        else
        {
            SetMovementAction(MovementActionType.Standard);
        }
    }
}