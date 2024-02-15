using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
 * [script for big UFO enemies]
 */

public class BigUFOScript : BaseUFOScript
{
    /// <summary>
    /// shoots in a random direction
    /// </summary>
    protected override void Shoot()
    {
        if (!_inCooldown)
        {
            Vector3 spawnDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            spawnDirection = transform.position + (spawnDirection * 1.5f);

            //https://medium.com/eincode/unity-fundamentals-rotate-a-game-object-in-movements-direction-9a62ec10a5c8
            Vector3 newDirection = (spawnDirection - transform.position).normalized;

            Debug.Log(newDirection);

            Quaternion bulletRotation = Quaternion.LookRotation(newDirection);

            GameObject bullet = Instantiate(_bulletPrefab, spawnDirection, bulletRotation);
            base.Shoot();
        }
    }
}
