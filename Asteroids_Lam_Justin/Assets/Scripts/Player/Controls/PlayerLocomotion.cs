using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/08/2024]
 * [moves player's game object]
 */

public class PlayerLocomotion : MonoBehaviour
{
    //needed components
    private InputManager _inputManager;
    private Rigidbody _rigidbody;

    //fire effect
    [SerializeField] private GameObject _fire;
    private bool _fireCoroutinePlaying = false;

    //variables for movement
    [SerializeField] private float _thrustForce = 15f;

    [SerializeField] private float _rotateSpeed = 275f;

    /// <summary>
    /// get needed components
    /// </summary>
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// moves player forward
    /// calls coroutine to show fire
    /// </summary>
    public void HandleThrust()
    {
        _rigidbody.AddForce(transform.up * _thrustForce * _inputManager.thrust);

        while (_inputManager.thrust > 0 && !_fireCoroutinePlaying)
        {
            StartCoroutine(ShowThrustFire());
        }
    }

    /// <summary>
    /// rotates player
    /// </summary>
    public void HandleRotation()
    {
        transform.Rotate(Vector3.forward * -_inputManager.rotate * _rotateSpeed * Time.deltaTime);
    }

    /// <summary>
    /// flashes fire effects
    /// </summary>
    /// <returns>how long does fire effect flash for</returns>
    private IEnumerator ShowThrustFire()
    {
        _fireCoroutinePlaying = true;
        _fire.SetActive(true);
        yield return new WaitForSeconds(0.05f);

        _fire.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        _fireCoroutinePlaying = false;
    }
}
