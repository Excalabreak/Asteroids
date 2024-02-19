using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [Manages the game]
 */

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _playerPrefab;

    private GameObject _currentPlayer;

    /// <summary>
    /// starts game on title screen
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        UIManager.Instance.ShowTitleScreen();
    }

    /// <summary>
    /// when player presses the play button,
    /// play the game
    /// </summary>
    public void Play()
    {
        PlayerData.Instance.ResetGame();
        UIManager.Instance.ShowGameUI();

        SpawnPlayer();
        PlayerData.Instance.NextLevel();
    }

    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(_playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public GameObject currentPlayer
    {
        get { return _currentPlayer; }
    }
}
