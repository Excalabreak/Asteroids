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
    PlayerControls _playerControls;

    public Vector2 _moveInput;

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

    /// <summary>
    /// disables _playerController when gameobject is disabled
    /// </summary>
    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
