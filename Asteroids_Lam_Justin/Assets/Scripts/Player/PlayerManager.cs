using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/08/2024]
 * [Manages player]
 */

public class PlayerManager : MonoBehaviour
{
    //components
    //input and movement
    private InputManager _inputManager;
    private PlayerLocomotion _playerLocomotion;

    /// <summary>
    /// get needed components
    /// </summary>
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    /// <summary>
    /// call functions needed for every frame
    /// </summary>
    private void Update()
    {
        _inputManager.HandleAllInputs();
        _playerLocomotion.HandleRotation();
    }

    /// <summary>
    /// call physics functions needed for every frame
    /// </summary>
    private void FixedUpdate()
    {
        _playerLocomotion.HandleThrust();
    }
}
