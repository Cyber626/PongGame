using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreText, enemyScoreText;
    [SerializeField] private Ball ballInstance;
    [SerializeField] private GameObject enemyPaddle;
    public static readonly float playerSpeed = 5;


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
