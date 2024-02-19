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

    private bool _playing = false;

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
        EnemyManager.Instance.RemoveAllEnemies();
        PlayerData.Instance.ResetGame();
        UIManager.Instance.ShowGameUI();

        SpawnPlayer();
        PlayerData.Instance.NextLevel();
        _playing = true;
    }

    public void OnLevelComplete()
    {
        _currentPlayer.GetComponent<PlayerSpawnScript>().Blink();
        PlayerData.Instance.NextLevel();
    }

    public void PlayingStopped()
    {
        _playing = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(_playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public GameObject currentPlayer
    {
        get { return _currentPlayer; }
    }

    public bool playing
    {
        get { return _playing; }
    }
}
