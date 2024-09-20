using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomGameMenuManager : MonoBehaviour
{
    [Header("Game Mode Fields")]
    [SerializeField] private Button toggleButton;
    [SerializeField] private GameObject botIcon, multiplayerIcon;
    [SerializeField] private Vector2 toggleOffPos, toggleOnPos;
    [SerializeField] private float toggleTransitionTime = .5f;
    [NonSerialized] public bool toggleMode = false;

    [Header("Match Setting Fields")]
    [SerializeField] private Slider matchDuriationSlider;
    [SerializeField] private TextMeshProUGUI matchDuriationSliderText;
    [SerializeField] private Slider ballSpeedSlider;
    [SerializeField] private TextMeshProUGUI ballSpeedSliderText;

    [Header("Player Setting Fields")]
    [SerializeField] private Slider paddleSizeSlider;
    [SerializeField] private TextMeshProUGUI paddleSizeSliderText;
    [SerializeField] private Slider paddleSpeedSlider;
    [SerializeField] private TextMeshProUGUI paddleSpeedSliderText;

    [Header("Enemy Setting Fields")]
    [SerializeField] private Slider paddle2SizeSlider;
    [SerializeField] private TextMeshProUGUI paddle2SizeSliderText;
    [SerializeField] private Slider paddle2SpeedSlider;
    [SerializeField] private TextMeshProUGUI paddle2SpeedSliderText;

    private void Start()
    {
        OnMatchDuriationSlider();
        OnBallSpeedSlider();
        OnPaddleSizeSlider();
        OnPaddleSpeedSlider();
        OnPaddle2SizeSlider();
        OnPaddle2SpeedSlider();
    }

    public void OnPaddle2SizeSlider()
    {
        int paddleSize = (int)paddle2SizeSlider.value;
        paddle2SizeSliderText.text = paddleSize.ToString();
        SceneLoader.Instance.enemyPaddleSize = paddleSize / 4f;
    }

    public void OnPaddle2SpeedSlider()
    {
        int paddleSpeed = (int)paddle2SpeedSlider.value;
        paddle2SpeedSliderText.text = paddleSpeed.ToString();
        SceneLoader.Instance.enemyPaddleSpeed = paddleSpeed / 10f;
    }

    public void OnPaddleSizeSlider()
    {
        int paddleSize = (int)paddleSizeSlider.value;
        paddleSizeSliderText.text = paddleSize.ToString();
        SceneLoader.Instance.playerPaddleSize = paddleSize / 4f;
    }

    public void OnPaddleSpeedSlider()
    {
        int paddleSpeed = (int)paddleSpeedSlider.value;
        paddleSpeedSliderText.text = paddleSpeed.ToString();
        SceneLoader.Instance.playerPaddleSpeed = paddleSpeed / 10f;
    }

    public void OnMatchDuriationSlider()
    {
        int matchDuriation = (int)matchDuriationSlider.value * 10;
        matchDuriationSliderText.text = matchDuriation.ToString();
        SceneLoader.Instance.matchDuriation = matchDuriation;
    }

    public void OnBallSpeedSlider()
    {
        int ballSpeedMultiplayer = (int)ballSpeedSlider.value * 10;
        ballSpeedSliderText.text = ballSpeedMultiplayer.ToString();
        SceneLoader.Instance.ballSpeedMultiplayer = ballSpeedMultiplayer;
    }

    public void OnGameModeToggle()
    {
        if (toggleMode)
        {
            toggleMode = false;
            toggleButton.transform.LeanMoveLocal(toggleOffPos, toggleTransitionTime).setEaseOutQuart();
            botIcon.transform.LeanScale(Vector2.one, toggleTransitionTime / 1.75f);
            multiplayerIcon.transform.LeanScale(Vector2.zero, toggleTransitionTime / 1.75f);
            SceneLoader.Instance.enemyType = SceneLoader.EnemyType.CustomAI;
        }
        else
        {
            toggleMode = true;
            toggleButton.transform.LeanMoveLocal(toggleOnPos, toggleTransitionTime).setEaseOutQuart();
            botIcon.transform.LeanScale(Vector2.zero, toggleTransitionTime / 1.75f);
            multiplayerIcon.transform.LeanScale(Vector2.one, toggleTransitionTime / 1.75f);
            SceneLoader.Instance.enemyType = SceneLoader.EnemyType.CustomHuman;
        }
    }
}
