using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/15/2024]
 * [base class for all UFO enemies]
 */

public class BaseUFOScript : BaseEnemyScript
{
    //variables for Shoot()
    protected bool _inCooldown = false;
    [SerializeField] protected float _cooldownTime = 3f;

    //Prefab for bullet
    [SerializeField] protected GameObject _bulletPrefab;

    /// <summary>
    /// one every frame,
    /// calls to shoot every frame
    /// </summary>
    private void Update()
    {
        Shoot();
    }

    //called in update to shoot
    protected virtual void Shoot() 
    {
        StartCoroutine(Cooldown());
    }

    protected IEnumerator Cooldown()
    {
        _inCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _inCooldown = false;
    }
}
