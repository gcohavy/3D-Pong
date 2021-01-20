using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        GAMEOVER
    }

    GameState _currentGameState = GameState.PREGAME;

    public Events.EventGameStateChange OnGameStateChange;

    public GameState CurrentGameState
    {
        get { return _currentGameState;}
        private set {_currentGameState = value; }
    }

    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        CurrentGameState = state;

        OnGameStateChange.Invoke(CurrentGameState, previousGameState);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        
    }
}
