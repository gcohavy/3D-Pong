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

    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _inGameMusic;
    [SerializeField] private AudioClip _gameOverMusic;

    public Events.EventGameStateChange OnGameStateChange;

    public GameState CurrentGameState
    {
        get { return _currentGameState;}
        private set {_currentGameState = value; }
    }

    void Start()
    {
        PlayMainMenuMusic();
    }

    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        CurrentGameState = state;

        OnGameStateChange.Invoke(CurrentGameState, previousGameState);

        if(CurrentGameState == GameState.GAMEOVER && previousGameState == GameState.RUNNING)
        {
            PlayGameOverMusic();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    public void PlayMainMenuMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _mainMenuMusic;
        _backgroundMusicSource.Play();
    }

    public void PlayInGameMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _inGameMusic;
        _backgroundMusicSource.Play();
    }

    public void PlayGameOverMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _gameOverMusic;
        _backgroundMusicSource.Play();
    }
}
