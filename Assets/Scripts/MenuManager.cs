using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button loadButton, multiplayerButton, botButton, easyButton, normalButton, hardButton;
    [SerializeField] private GameObject botModeField;
    [SerializeField] private Vector2 botInitialPosition = new Vector2(0, 340), botMovedPosition = new Vector2(-350, 340);
    [SerializeField] private float transitionTime = .5f;
    private Color32 selectedColor = new(165, 242, 162, 255);

    private void Start()
    {
        loadButton.interactable = false;
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
        botButton.GetComponent<Image>().color = selectedColor;
        botButton.transform.LeanMoveLocal(botMovedPosition, transitionTime).setEaseOutQuart();
        botModeField.transform.LeanScale(Vector2.one, transitionTime / 1.75f);
    }

    public void SelectMultiplayer()
    {
        botButton.GetComponent<Image>().color = Color.white;
        multiplayerButton.GetComponent<Image>().color = selectedColor;
        botButton.transform.LeanMoveLocal(botInitialPosition, transitionTime).setEaseInQuart();
        botModeField.transform.LeanScale(Vector2.zero, transitionTime / 1.75f);
        SceneLoader.Instance.enemyType = SceneLoader.EnemyType.Human;
        loadButton.interactable = true;
    }
}
