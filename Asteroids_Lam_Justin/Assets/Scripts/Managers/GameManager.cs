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
    //player prefab
    [SerializeField] private GameObject _playerPrefab;

    //current instance of player
    private GameObject _currentPlayer;

    //is the game playing
    private bool _playing = false;

    /// <summary>
    /// starts game on title screen
    /// </summary>
    private void Start()
    {
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

    /// <summary>
    /// Call the level is complete
    /// and go to the next level
    /// </summary>
    public void OnLevelComplete()
    {
        _currentPlayer.GetComponent<PlayerSpawnScript>().Blink();
        PlayerData.Instance.NextLevel();
    }

    /// <summary>
    /// swich _playing to false when not playing game
    /// </summary>
    public void PlayingStopped()
    {
        _playing = false;
    }

    /// <summary>
    /// Quits the application
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// spawns player
    /// </summary>
    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(_playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    /// <summary>
    /// get the current player
    /// </summary>
    public GameObject currentPlayer
    {
        get { return _currentPlayer; }
    }

    /// <summary>
    /// get if game is playing
    /// </summary>
    public bool playing
    {
        get { return _playing; }
    }
}
