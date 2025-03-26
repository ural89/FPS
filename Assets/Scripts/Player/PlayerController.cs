using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float lookXLimit = 90f;
    private Camera playerCamera;
    private CharactermovementHandler charactermovementHandler;
    private PlayerInteractor playerInteractor;
    private Vector2 moveInput;
    private float rotationX = 0;


    private void Awake()
    {
        charactermovementHandler = GetComponent<CharactermovementHandler>();
        playerInteractor = GetComponent<PlayerInteractor>();
    }
    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        charactermovementHandler.SetMovementInput(moveInput);
    }

    private void HandleInteract()
    {
        var interactable = playerInteractor.InteractWithRaycast();
    }



    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            charactermovementHandler.SetIsRunning(true);
        }
        else if (context.canceled)
        {
            charactermovementHandler.SetIsRunning(false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            charactermovementHandler.SetJumpInput(true);
        }
        else if (context.canceled)
        {
            charactermovementHandler.SetJumpInput(false);
        }

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HandleInteract();
        }

    }


}