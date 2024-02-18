using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/13/2024]
 * [gets all the inputs from the input system and calls functions to handle them]
 */
public class InputManager : MonoBehaviour
{
    //input action
    private PlayerControls _playerControls;

    //needed components
    private ShootScript _shootScript;
    private HyperSpaceScript _hyperSpaceScript;

    //movement
    private Vector2 _moveInput;
    private float _thrust;
    private float _rotate;

    //actions
    private bool _shoot = false;
    private bool _hyperSpace;

    /// <summary>
    /// get needed components
    /// </summary>
    private void Awake()
    {
        _shootScript = GetComponent<ShootScript>();
        _hyperSpaceScript = GetComponent<HyperSpaceScript>();
    }

    /// <summary>
    /// on enable:
    /// makes new PlayerController if there isnt already one
    /// sets up callback contexts
    /// 
    /// enables _playerController
    /// </summary>
    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovement.Movement.performed += context => _moveInput = context.ReadValue<Vector2>();

            _playerControls.PlayerAction.Shoot.performed += context => _shoot = true;
            _playerControls.PlayerAction.HyperSpace.performed += context => _hyperSpace = true;
        }

        _playerControls.Enable();
    }

    /// <summary>
    /// calls all functions for inputs
    /// </summary>
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleShootInput();
        HandleHyperSpaceInput();
    }

    /// <summary>
    /// sets movement variables from inputs
    /// </summary>
    private void HandleMovementInput()
    {
        _thrust = _moveInput.y;
        _rotate = _moveInput.x;
    }

    /// <summary>
    /// calls to shoot when inputted
    /// </summary>
    private void HandleShootInput()
    {
        if (_shoot)
        {
            _shoot = false;
            _shootScript.Shoot();
        }
    }

    private void HandleHyperSpaceInput()
    {
        if (_hyperSpace)
        {
            _hyperSpace = false;
            _hyperSpaceScript.Teleport();
        }
    }

    /// <summary>
    /// disables _playerController when gameobject is disabled
    /// </summary>
    private void OnDisable()
    {
        _playerControls.Disable();
    }

    /// <summary>
    /// property to get _thrust
    /// </summary>
    public float thrust
    {
        get { return _thrust; }
    }

    /// <summary>
    /// property to get _rotate
    /// </summary>
    public float rotate
    {
        get { return _rotate; }
    }
}
