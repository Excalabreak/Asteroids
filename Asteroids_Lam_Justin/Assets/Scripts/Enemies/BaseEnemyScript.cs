using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
 * [base class for all enemies to inherit from]
 */

public class BaseEnemyScript : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _points;
    [SerializeField] protected EnemyType _enemyType;

    /// <summary>
    /// when any enemy dies:
    /// send points to player data
    /// destroys this game object
    /// </summary>
    protected virtual void OnDeath()
    {
        PlayerData.Instance.AddScore(_points);
        Destroy(gameObject);
    }

    /// <summary>
    /// if collides with anything that isn't an enemy, call OnDeath
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != _enemyType.ToString())
        {
            OnDeath();
        }
    }
}
