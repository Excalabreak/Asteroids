using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/13/2024]
 * [bullets will move forward until time or they collide with something]
 */

public class BulletScript : MonoBehaviour
{
    //variables for how fast and how long the bullet is
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _time = 3f;

    //for velocity
    private Rigidbody _rigidbody;

    /// <summary>
    /// on awake,
    /// set velocity to _speed
    /// destroy affter _time
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.up * _speed;

        Destroy(gameObject, _time);
    }

    /// <summary>
    /// on collision enter:
    /// destroy self
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
