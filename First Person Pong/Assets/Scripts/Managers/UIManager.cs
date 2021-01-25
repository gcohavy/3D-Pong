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
        _pregameMenu.SetBackToActive();
        _mainMenu.SlideUp();
        GameManager.Instance.PlayInGameMusic();
    }

    public void OptionsButton()
    {
        _optionsMenu.SlideIn();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    //Options Menu
    public void BackButton()
    {
        _optionsMenu.SlideOut();
    }

    //--Difficulty buttons--
    public void EasyDifficulty()
    {
        GameManager.Instance.UpdateDifficulty(GameManager.Difficulty.EASY);
    }
    public void MediumDifficulty()
    {
        GameManager.Instance.UpdateDifficulty(GameManager.Difficulty.MEDIUM);
    }
    public void HardDifficulty()
    {
        GameManager.Instance.UpdateDifficulty(GameManager.Difficulty.HARD);
    }

    //Pregame menu
    public void BeginButton()
    {
        _pregameMenu.BeginCountdown();
    }

    //EndgameMenu
    public void RestartButton()
    {
        _pregameMenu.SetBackToActive();
        _endGameMenu.gameObject.SetActive(false);
        GameManager.Instance.PlayInGameMusic();
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
    }

    public void ExitToMainButton()
    {
        _endGameMenu.gameObject.SetActive(false);
        _mainMenu.SlideDown();
        GameManager.Instance.PlayMainMenuMusic();
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
    }
}
