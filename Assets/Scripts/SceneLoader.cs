using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance {  get; private set; }
    public enum EnemyType
    { 
        Human,
        EasyAI,
        NormalAI,
        HardAI,
        CustomHuman,
        CustomAI,
    }

    // Custom settings
    public EnemyType enemyType = EnemyType.HardAI;
    public int matchDuriation = 120;
    public int ballSpeedMultiplayer = 100;
    public float playerPaddleSize = 2, playerPaddleSpeed = 1;
    public float enemyPaddleSize = 2, enemyPaddleSpeed = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
