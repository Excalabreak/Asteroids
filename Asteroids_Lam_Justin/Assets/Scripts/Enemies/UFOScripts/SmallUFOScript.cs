using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [script for small ufo]
 */

public class SmallUFOScript : BaseUFOScript
{
    private Transform _playerLocation;
    [SerializeField] private float _accuracyMod = 5000f;
    [SerializeField] private float _accuracyExtremes = 20f;

    /// <summary>
    /// will shoot at player
    /// becomes more accurete as player score goes up
    /// </summary>
    protected override void Shoot()
    {
        if (!_inCooldown && _playerLocation != null)
        {
            float bulletSpread = _accuracyExtremes - (_accuracyExtremes * (PlayerData.Instance.currentScore / _accuracyMod));
            bulletSpread = Mathf.Clamp(bulletSpread, .01f, _accuracyExtremes);

            Vector3 spawnLocation = new Vector3(_playerLocation.position.x + Random.Range(-bulletSpread, bulletSpread) - transform.position.x, _playerLocation.position.y + Random.Range(-bulletSpread, bulletSpread) - transform.position.y, 0f).normalized;
            spawnLocation = new Vector3(transform.position.x + (spawnLocation.x), transform.position.y + (spawnLocation.y), 0f);

            Vector3 bulletDirection = spawnLocation - transform.position;
            float angle = Vector3.Angle(bulletDirection, transform.up);

            if (spawnLocation.x > transform.position.x)
            {
                angle = angle * -1;
            }

            GameObject bullet = Instantiate(_bulletPrefab, spawnLocation, Quaternion.Euler(0f, 0f, angle), null);
            base.Shoot();
        }
    }

    /// <summary>
    /// constantly getting player location
    /// </summary>
    protected override void Update()
    {
        if (_playerLocation == null)
        {
            GetPlayerLoc();
        }

        base.Update();
    }

    /// <summary>
    /// calls to get player's transform
    /// </summary>
    private void GetPlayerLoc()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            _playerLocation = player.transform;
        }
    }
}
