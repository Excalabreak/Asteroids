using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/13/2024]
 * [instantiates a bullet infront of player]
 */

public class ShootScript : MonoBehaviour
{
    //prefab for bullet
    [SerializeField] private GameObject _bulletPrefab;

    /// <summary>
    /// when called, instantiates a bullet in front of the player
    /// </summary>
    public void Shoot()
    {
        Vector3 spawn = transform.position + (transform.up * 0.75f);

        GameObject bullet = Instantiate(_bulletPrefab, spawn, transform.rotation);
    }
}
