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
            Vector3 spawnLocation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            spawnLocation = transform.position + (spawnLocation * 1.5f);

            Vector3 bulletDirection = spawnLocation - transform.position;
            float angle = Vector3.Angle(bulletDirection, transform.up);

            if (spawnLocation.x > transform.position.x)
            {
                angle = angle * -1;
            }

            GameObject bullet = Instantiate(_bulletPrefab, spawnLocation, Quaternion.Euler(0f, 0f, angle));
            base.Shoot();
        }
    }
}
