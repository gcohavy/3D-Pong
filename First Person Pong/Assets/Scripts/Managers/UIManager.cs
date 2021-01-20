using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private EndGameMenu _endGameMenu;

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
    }
}
