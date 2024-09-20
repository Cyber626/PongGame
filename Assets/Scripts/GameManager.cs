using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI playerScoreText, enemyScoreText, timerText;
    [SerializeField] private Ball ballInstance;
    [SerializeField] private GameObject enemyPaddle, endGameMenu, pauseMenu;
    public float matchTimeInSeconds = 120;


    public int playerScore { get; private set; }
    public int enemyScore { get; private set; }


    private void Start()
    {
        Time.timeScale = 1;
        playerScore = 0;
        enemyScore = 0;
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.Human)
        {
            enemyPaddle.AddComponent<EnemyPlayer>();
        }
        else if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.CustomHuman || SceneLoader.Instance.enemyType == SceneLoader.EnemyType.CustomAI)
        {
            // General custom settings apply
            matchTimeInSeconds = SceneLoader.Instance.matchDuriation;
            ballInstance.ballSpeedMultiplayer = SceneLoader.Instance.ballSpeedMultiplayer / 100f;
            player.transform.localScale = new(player.transform.localScale.x,
                SceneLoader.Instance.playerPaddleSize, player.transform.localScale.z);
            player.speed = player.speed * SceneLoader.Instance.playerPaddleSpeed;

            if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.CustomHuman)
            {
                EnemyPlayer enemyPlayer = enemyPaddle.AddComponent<EnemyPlayer>();
                enemyPlayer.transform.localScale = new(enemyPlayer.transform.localScale.x,
                    SceneLoader.Instance.enemyPaddleSize, enemyPlayer.transform.localScale.z);
                enemyPlayer.speed = enemyPlayer.speed * SceneLoader.Instance.enemyPaddleSpeed;
            }
            else
            {
                EnemyController enemyController = enemyPaddle.AddComponent<EnemyController>();
                enemyController.ball = ballInstance;
                enemyController.transform.localScale = new(enemyController.transform.localScale.x,
                    SceneLoader.Instance.enemyPaddleSize, enemyController.transform.localScale.z);
                enemyController.speed = enemyController.speed * SceneLoader.Instance.enemyPaddleSpeed;
            }
        }
        else
        {
            EnemyController enemyController = enemyPaddle.AddComponent<EnemyController>();
            enemyController.ball = ballInstance;
            if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.EasyAI) enemyController.speed = 5;
            else if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.NormalAI) enemyController.speed = 6;
            else if (SceneLoader.Instance.enemyType == SceneLoader.EnemyType.HardAI) enemyController.speed = 7;
        }
        StartCoroutine(ballInstance.StartFromCenter());
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
        SceneManager.LoadScene(1);
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
