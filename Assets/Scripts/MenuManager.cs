using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject botModeField;
    [SerializeField] private Button loadButton, multiplayerButton, customButton, botButton, easyButton, normalButton, hardButton;

    [Header("Bot button movement")]
    [SerializeField] private Vector2 botInitialPosition = new Vector2(0, 340);
    [SerializeField] private Vector2 botMovedPosition = new Vector2(-350, 340);
    [SerializeField] private float botTransitionTime = .5f;

    [Header("Custom button movements")]
    [SerializeField] private CustomGameMenuManager customGameMenuManager;
    [SerializeField] private GameObject customSettingsField;
    [SerializeField] private Vector2 initialMultiplayerPos, initialCustomPos;
    [SerializeField] private Vector2 movedBotPos, movedMultiplayerPos, movedCustomPos;
    [SerializeField] private float customTransitionTime = .5f;

    private bool customButtonFlag = false;
    private Color32 selectedColor = new(165, 242, 162, 255);

    private void Start()
    {
        loadButton.interactable = false;
        Time.timeScale = 1;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectEasyMode()
    {
        normalButton.GetComponent<Image>().color = Color.white;
        hardButton.GetComponent<Image>().color = Color.white;
        easyButton.GetComponent<Image>().color = selectedColor;
        SceneLoader.Instance.enemyType = SceneLoader.EnemyType.EasyAI;
        loadButton.interactable = true;
    }
    public void SelectNormalMode()
    {
        hardButton.GetComponent<Image>().color = Color.white;
        easyButton.GetComponent<Image>().color = Color.white;
        normalButton.GetComponent<Image>().color = selectedColor;
        SceneLoader.Instance.enemyType = SceneLoader.EnemyType.NormalAI;
        loadButton.interactable = true;
    }
    public void SelectHardMode()
    {
        normalButton.GetComponent<Image>().color = Color.white;
        easyButton.GetComponent<Image>().color = Color.white;
        hardButton.GetComponent<Image>().color = selectedColor;
        SceneLoader.Instance.enemyType = SceneLoader.EnemyType.HardAI;
        loadButton.interactable = true;
    }

    public void SelectBot()
    {
        multiplayerButton.GetComponent<Image>().color = Color.white;
        customButton.GetComponent<Image>().color = Color.white;
        botButton.GetComponent<Image>().color = selectedColor;
        loadButton.interactable = false;
        normalButton.GetComponent<Image>().color = Color.white;
        easyButton.GetComponent<Image>().color = Color.white;
        hardButton.GetComponent<Image>().color = Color.white;

        if (customButtonFlag)
        {
            customButtonFlag = false;
            ReturnButtons(true);
        }

        botButton.transform.LeanMoveLocal(botMovedPosition, botTransitionTime).setEaseOutQuart();
        botModeField.transform.LeanScale(Vector2.one, botTransitionTime / 1.75f);
    }

    public void SelectMultiplayer()
    {
        botButton.GetComponent<Image>().color = Color.white;
        customButton.GetComponent<Image>().color = Color.white;
        multiplayerButton.GetComponent<Image>().color = selectedColor;

        if (customButtonFlag)
        {
            customButtonFlag = false;
            ReturnButtons(false);
        }

        botButton.transform.LeanMoveLocal(botInitialPosition, botTransitionTime).setEaseInQuart();
        botModeField.transform.LeanScale(Vector2.zero, botTransitionTime / 1.75f);
        SceneLoader.Instance.enemyType = SceneLoader.EnemyType.Human;
        loadButton.interactable = true;
    }

    public void SelectCustom()
    {
        botButton.GetComponent<Image>().color = Color.white;
        multiplayerButton.GetComponent<Image>().color = Color.white;
        customButton.GetComponent<Image>().color = selectedColor;

        if (!customButtonFlag)
        {
            customButtonFlag = true;
            MoveButtons();
        }

        if (customGameMenuManager.toggleMode)
        {
            SceneLoader.Instance.enemyType = SceneLoader.EnemyType.CustomHuman;

        }
        else
        {
            SceneLoader.Instance.enemyType = SceneLoader.EnemyType.CustomAI;
        }

        loadButton.interactable = true;
    }
    private void MoveButtons()
    {
        botButton.transform.LeanMoveLocal(movedBotPos, customTransitionTime).setEaseOutQuart();
        multiplayerButton.transform.LeanMoveLocal(movedMultiplayerPos, customTransitionTime).setEaseOutQuart();
        customButton.transform.LeanMoveLocal(movedCustomPos, customTransitionTime).setEaseOutQuart();

        botModeField.transform.LeanScale(Vector2.zero, botTransitionTime / 1.75f);
        customSettingsField.transform.LeanScale(Vector2.one, customTransitionTime / 1.75f);
    }

    private void ReturnButtons(bool isBotModeSelected)
    {
        if (isBotModeSelected)
        {
            botModeField.transform.LeanScale(Vector2.one, botTransitionTime / 1.75f);
        }
        else
        {
            botButton.transform.LeanMoveLocal(botInitialPosition, customTransitionTime).setEaseInQuart();
        }

        multiplayerButton.transform.LeanMoveLocal(initialMultiplayerPos, customTransitionTime).setEaseInQuart();
        customButton.transform.LeanMoveLocal(initialCustomPos, customTransitionTime).setEaseInQuart();

        customSettingsField.transform.LeanScale(Vector2.zero, customTransitionTime / 1.75f);
    }
}
