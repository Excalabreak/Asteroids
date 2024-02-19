using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [when called, teleports players]
 */

public class HyperSpaceScript : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private float _teleportTime = 0.1f;
    private bool _isTeleporting = false;

    /// <summary>
    /// checks if player is teleporting then starts the coroutine
    /// </summary>
    public void Teleport()
    {
        if (!_isTeleporting)
        {
            _isTeleporting = true;
            StartCoroutine(Blink());
        }
    }

    /// <summary>
    /// teleports player to random space
    /// </summary>
    /// <returns></returns>
    private IEnumerator Blink()
    {
        _model.SetActive(false);

        yield return new WaitForSeconds(_teleportTime);

        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        Vector3 newLocation = new Vector3(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y), 0f);
        transform.position = newLocation;

        _model.SetActive(true);

        _isTeleporting = false;
    }
}
