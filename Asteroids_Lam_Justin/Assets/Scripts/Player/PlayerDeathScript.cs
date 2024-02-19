using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [Handles death on collision]
 */

public class PlayerDeathScript : MonoBehaviour
{
    //makes sure only hit's once
    private bool _hasHit = false;

    /// <summary>
    /// on collision enter,
    /// tell player data that the player died
    /// destroy this game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!_hasHit)
        {
            _hasHit = true;
            PlayerData.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
