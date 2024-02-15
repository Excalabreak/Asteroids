using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
 * [script for asteroid enemies]
 */

public class AsteroidScript : BaseEnemyScript
{
    //needed components
    private Rigidbody _rigidbody;

    //prefab for next game object
    [SerializeField] private GameObject _nextAsteroidPrefab;

    //what direction will asteroid go
    private Vector3 _direction;

    /// <summary>
    /// on awake, set the rotation and direction of the asteroid
    /// use those to set the velocity of rigid body
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //if the meteor was more thant just a circle
        transform.Rotate(Vector3.forward * Random.Range(0f, 359f));
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;

        _rigidbody.velocity = _direction * _speed;
    }

    /// <summary>
    /// on Death, if it has a _nextAsteroidPrefab,
    /// spawn next asteroid
    /// call base OnDeath()
    /// </summary>
    protected override void OnDeath()
    {
        if (_nextAsteroidPrefab != null)
        {
            GameObject spawn1 = Instantiate(_nextAsteroidPrefab, transform.position, Quaternion.identity);
            GameObject spawn2 = Instantiate(_nextAsteroidPrefab, transform.position, Quaternion.identity);
        }

        base.OnDeath();
    }
}
