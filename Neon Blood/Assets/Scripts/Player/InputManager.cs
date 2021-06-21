using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerInput controls;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
        controls = new PlayerInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return controls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseLook()
    {
        return controls.Player.MouseLook.ReadValue<Vector2>();
    }

    public Vector2 GetControllerLook()
    {
        return controls.Player.ControllerLook.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return controls.Player.Jump.triggered;
    }


    public bool PlayerInteractedThisFrame()
    {
        return controls.Player.Interact.triggered;
    }


    public bool PlayerCrouchedThisFrame()
    {
        return controls.Player.CrouchStart.triggered;
    }

    public bool PlayerUncrouchedThisFrame()
    {
        return controls.Player.CrouchEnd.triggered;
    }


    public bool PlayerShotThisFrame()
    {
        return controls.Player.ShootStart.triggered;
    }

    public bool PlayerStoppedShootingThisFrame()
    {
        return controls.Player.ShootStop.triggered;
    }


    public bool PlayerZoomedThisFrame()
    {
        return controls.Player.ZoomStart.triggered;
    }

    public bool PlayerStopZoomedThisFrame()
    {
        return controls.Player.ZoomEnd.triggered;
    }


    public bool PlayerSprintingThisFrame()
    {
        return controls.Player.SprintStart.triggered;
    }

    public bool PlayerStoppedSprintingThisFrame()
    {
        return controls.Player.SprintStop.triggered;
    }
}
