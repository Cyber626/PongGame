using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI playerScoreText, enemyScoreText;

    public int playerScore { get; private set; }
    public int enemyScore { get; private set; }

    private void Start()
    {
        playerScore = 0;
        enemyScore = 0;
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
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
