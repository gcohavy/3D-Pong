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

    //Handle Game over
    public void GameOver(bool won)
    {
        if(won) _endGameMenu.GameWon();
        else _endGameMenu.GameLost();
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.RUNNING)
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
        GameManager.Instance.BeginBackgroundAnimation();
    }

    public void OptionsButton()
    {
        _optionsMenu.SlideIn();
    }

    public void AboutButton()
    {
        _mainMenu.MenuOptionsFadeOut();
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
        _endGameMenu.ResetInactive();
        GameManager.Instance.PlayInGameMusic();
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
    }

    public void ExitToMainButton()
    {
        _endGameMenu.ResetInactive();
        _mainMenu.SlideDown();
        GameManager.Instance.PlayMainMenuMusic();
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
        GameManager.Instance.StopBackgroundAnimation();
    }

    //About Section
    public void AboutBackButton()
    {
        _mainMenu.AboutMenuFadeOut();
    }
}
