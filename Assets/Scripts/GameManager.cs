using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreText, enemyScoreText, timerText;
    [SerializeField] private Ball ballInstance;
    [SerializeField] private GameObject enemyPaddle, endGameMenu, pauseMenu;
    public static readonly float playerSpeed = 5;
    public float matchTimeInSeconds = 120;


    public int playerScore { get; private set; }
    public int enemyScore { get; private set; }


    private void Start()
    {
        playerScore = 0;
        enemyScore = 0;
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.Human)
        {
            enemyPaddle.AddComponent<EnemyPlayer>();
        }
        else
        {
            EnemyController enemyController = enemyPaddle.AddComponent<EnemyController>();
            enemyController.ball = ballInstance;
            if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.EasyAI) enemyController.speed = 5;
            else if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.NormalAI) enemyController.speed = 6;
            else if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.HardAI) enemyController.speed = 7;
        }
    }

    private void Update()
    {
        if (matchTimeInSeconds <= 0)
        {
            Time.timeScale = 0;
            endGameMenu.SetActive(true);
        }
        else
        {
            matchTimeInSeconds -= Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(matchTimeInSeconds).ToString(@"mm\:ss");
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void EnemyScored()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }

    public void PlayerScored()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
}
