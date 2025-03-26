using UnityEngine;

public interface IMovementAction
{
    void Move(CharacterController controller, Transform transform, Vector2 input);
    void ApplyGravity(ref Vector3 moveDirection, float gravity, float deltaTime);
    void HandleJump(ref Vector3 moveDirection, float jumpSpeed);
}

public class StandardMovementAction : IMovementAction
{ 
    private PlayerData playerData;
    public StandardMovementAction(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    public void Move(CharacterController controller, Transform transform, Vector2 input)
    {
        Vector3 moveDirection = new Vector3(input.x, 0.0f, input.y);
        moveDirection = transform.TransformDirection(moveDirection) * playerData.GetMoveSpeed();
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void ApplyGravity(ref Vector3 moveDirection, float gravity, float deltaTime)
    {
        moveDirection.y += gravity * deltaTime;
    }

    public void HandleJump(ref Vector3 moveDirection, float jumpSpeed)
    {
        moveDirection.y = jumpSpeed;
    }
}

public class RunMovementAction : IMovementAction
{
    private PlayerData playerData;
    public RunMovementAction(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    public void Move(CharacterController controller, Transform transform, Vector2 input)
    {
        Vector3 moveDirection = new Vector3(input.x, 0.0f, input.y);
        moveDirection = transform.TransformDirection(moveDirection) * playerData.GetRunSpeed();
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void ApplyGravity(ref Vector3 moveDirection, float gravity, float deltaTime)
    {
        moveDirection.y += gravity * deltaTime * 0.8f;
    }

    public void HandleJump(ref Vector3 moveDirection, float jumpSpeed)
    {
        moveDirection.y = jumpSpeed * 0.7f;
    }
}