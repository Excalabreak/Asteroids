using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * Author: [Lam, Justin]
 * Last Updated: [02/18/2024]
 * [manages ui components]
 */

public class UIManager : Singleton<UIManager>
{
    //text
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _highScoreGameText;
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _highScoreTitleText;

    //buttons
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _playText;
    [SerializeField] private GameObject _loadButton;
    [SerializeField] private GameObject _quitButton;
    [SerializeField] private RectTransform _quitButtonPos;

    /// <summary>
    /// hides all UI
    /// </summary>
    public void HideAllUI()
    {
        _levelText.enabled = false;
        _scoreText.enabled = false;
        _livesText.enabled = false;
        _highScoreGameText.enabled = false;
        _titleText.enabled = false;
        _highScoreTitleText.enabled = false;
        _playButton.SetActive(false);
        _loadButton.SetActive(false);
        _quitButton.SetActive(false);
    }

    /// <summary>
    /// shows the title screen
    /// </summary>
    public void ShowTitleScreen()
    {
        HideAllUI();

        _titleText.enabled = true;
        _titleText.text = "ASTEROIDS";

        _highScoreTitleText.enabled = true;
        _highScoreTitleText.text = "*Current High Score*\n" + PlayerData.Instance.highScore;

        _playButton.SetActive(true);
        _playText.text = "Play";

        _loadButton.SetActive(true);

        _quitButton.SetActive(true);
        _quitButtonPos.anchoredPosition = new Vector2(0, -120);
    }

    public void ShowGameUI()
    {
        HideAllUI();
        _levelText.enabled = true;
        _scoreText.enabled = true;
        _livesText.enabled = true;
        _highScoreGameText.enabled = true;
    }

    public void ShowGameOverUI(bool newHighScore)
    {
        HideAllUI();

        _levelText.enabled = true;
        _scoreText.enabled = true;

        _titleText.enabled = true;
        _titleText.text = "GAME OVER";

        _highScoreTitleText.enabled = true;
        if (newHighScore)
        {
            _highScoreTitleText.text = "***NEW HIGH SCORE***\n" + PlayerData.Instance.highScore;
        }
        else
        {
            _highScoreTitleText.text = "*Current High Score*\n" + PlayerData.Instance.highScore;
        }

        _playButton.SetActive(true);
        _playText.text = "Replay";

        _quitButton.SetActive(true);
        _quitButtonPos.anchoredPosition = new Vector2(0, -80);
    }    

    public void UpdateGameUI()
    {
        _levelText.text = "Level: " + PlayerData.Instance.currentLevel;
        _scoreText.text = "Score: " + PlayerData.Instance.currentScore;
        _livesText.text = "Lives: " + PlayerData.Instance.numberOfLives;
        _highScoreGameText.text = "High Score\n" + PlayerData.Instance.highScore;
    }
}
