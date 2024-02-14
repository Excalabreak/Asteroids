using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/07/2024]
 * [gets all the inputs from the input system and calls functions to handle them]
 */
public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;

    private Vector2 _moveInput;
    private float _thrust;
    private float _rotate;

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
        }

        _playerControls.Enable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        _thrust = _moveInput.y;
        _rotate = _moveInput.x;
    }

    /// <summary>
    /// disables _playerController when gameobject is disabled
    /// </summary>
    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public float thrust
    {
        get { return _thrust; }
    }

    public float rotate
    {
        get { return _rotate; }
    }
}
