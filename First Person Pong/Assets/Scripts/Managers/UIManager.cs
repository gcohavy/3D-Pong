using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private PregameMenu _pregameMenu;

    void Start()
    {
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        //Handle when the game ends
        if(currentState == GameManager.GameState.GAMEOVER && previousState == GameManager.GameState.RUNNING)
        {
            _endGameMenu.GameLost();
        }
        else if (currentState == GameManager.GameState.RUNNING)
        {
            _pregameMenu.gameObject.SetActive(false);
        }
    }

    //Button actions

    //Main Menu
    public void StartButton()
    {
        _pregameMenu.gameObject.SetActive(true);
        _mainMenu.SlideUp();
        GameManager.Instance.PlayInGameMusic();
    }

    public void OptionsButton()
    {
        _optionsMenu.SlideIn();
    }

    //Options Menu
    public void BackButton()
    {
        _optionsMenu.SlideOut();
    }

    //Pregame menu
    public void BeginButton()
    {
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }
}
