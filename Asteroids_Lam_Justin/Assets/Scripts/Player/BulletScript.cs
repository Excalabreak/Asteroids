using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
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
    /// destroy self when triggered
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
