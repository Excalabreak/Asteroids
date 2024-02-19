using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [Handles everything when player gets instatiated]
 */

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;
    [SerializeField] private GameObject _model;
    [SerializeField] private float _blinkTime;
    [SerializeField] private int _blinkAmount;

    /// <summary>
    /// calls to start blinking when created
    /// </summary>
    private void Awake()
    {
        Blink();
    }

    /// <summary>
    /// so player can blink when called
    /// </summary>
    public void Blink()
    {
        StartCoroutine(SpawnBlink());
    }

    /// <summary>
    /// makes player invulnerable while blinking
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnBlink()
    {
        foreach (Collider collider in _colliders)
        {
            collider.enabled = false;
        }

        for (int index = 0; index < _blinkAmount; index++)
        {
            _model.SetActive(true);
            yield return new WaitForSeconds(_blinkTime);


            _model.SetActive(false);
            yield return new WaitForSeconds(_blinkTime);
        }
        _model.SetActive(true);

        foreach (Collider collider in _colliders)
        {
            collider.enabled = true;
        }
    }
}
