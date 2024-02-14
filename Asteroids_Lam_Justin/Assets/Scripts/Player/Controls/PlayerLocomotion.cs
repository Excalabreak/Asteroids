using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private InputManager _inputManager;
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject _fire;
    private bool _fireCoroutinePlaying = false;

    [SerializeField] private float _thrustForce = 15f;

    [SerializeField] private float _rotateSpeed = 275f;


    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void HandleThrust()
    {
        _rigidbody.AddForce(transform.up * _thrustForce * _inputManager.thrust);

        while (_inputManager.thrust > 0 && !_fireCoroutinePlaying)
        {
            StartCoroutine(ShowThrustFire());
        }
    }

    public void HandleRotation()
    {
        transform.Rotate(Vector3.forward * -_inputManager.rotate * _rotateSpeed * Time.deltaTime);
    }

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
