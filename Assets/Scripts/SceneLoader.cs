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
    }

    [NonSerialized] public EnemyType enemyType = EnemyType.HardAI;

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

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
