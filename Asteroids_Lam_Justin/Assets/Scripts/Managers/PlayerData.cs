using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [Manages all player data]
 */

public class PlayerData : Singleton<PlayerData>
{
    //TODO: make sure game gets saved by level so 
    //all required numbers
    [SerializeField] private int _numberOfLives = 0;
    [SerializeField] private int _currentScore = 0;
    [SerializeField] private int _highScore = 0;
    [SerializeField] private int _currentLevel = 0;

    //if designer wants to change score
    [SerializeField] private int _maxLives = 3;

    private bool _gotNewHighScore = false;

    /// <summary>
    /// called to update lives when player dies
    /// </summary>
    public void LoseLife()
    {
        _numberOfLives--;
        UIManager.Instance.UpdateGameUI();
        if (_numberOfLives <= 0)
        {
            OnGameOver();
        }
        else
        {
            GameManager.Instance.SpawnPlayer();
        }
    }

    /// <summary>
    /// calls to add to points
    /// </summary>
    /// <param name="score">the amount of score added</param>
    public void AddScore(int score)
    {
        _currentScore += score;
        CheckNewHighScore();
        UIManager.Instance.UpdateGameUI();
    }

    /// <summary>
    /// called to check if the player won
    /// else call to play next level
    /// </summary>
    public void NextLevel()
    {
        _currentLevel++;
        UIManager.Instance.UpdateGameUI();
        EnemyManager.Instance.SpawnEnemies();
    }

    /// <summary>
    /// called when player loses
    /// </summary>
    private void OnGameOver()
    {
        CheckNewHighScore();
        UIManager.Instance.UpdateGameUI();
        UIManager.Instance.ShowGameOverUI(_gotNewHighScore);
    }

    /// <summary>
    /// called to check if player has new high score
    /// </summary>
    private void CheckNewHighScore()
    {
        if (_currentScore > _highScore)
        {
            _highScore = _currentScore;
            _gotNewHighScore = true;
        }
        UIManager.Instance.UpdateGameUI();
    }

    public void ResetGame()
    {
        _numberOfLives = _maxLives;
        _currentScore = 0;
        _currentLevel = 0;
    }

    /// <summary>
    /// get _numberOfLives 
    /// </summary>
    public int numberOfLives
    {
        get { return _numberOfLives; }
    }

    /// <summary>
    /// get _currentScore
    /// </summary>
    public int currentScore
    {
        get { return _currentScore; }
    }

    /// <summary>
    /// get _highScore
    /// </summary>
    public int highScore
    {
        get { return _highScore; }
    }

    /// <summary>
    /// get currentLevel
    /// </summary>
    public int currentLevel
    {
        get { return _currentLevel; }
    }
}
