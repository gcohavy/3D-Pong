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

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }

    GameState _currentGameState = GameState.PREGAME;
    Difficulty _currentDifficulty = Difficulty.MEDIUM;

    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _inGameMusic;
    [SerializeField] private AudioClip _gameOverMusic;

    [SerializeField] private Animation _backgroundAnimationComponent;
    [SerializeField] private AnimationClip _backgroundAnimation;

    public Events.EventGameStateChange OnGameStateChange;
    public Events.EventDifficultyChange OnDifficultyChange;

    public GameState CurrentGameState
    {
        get { return _currentGameState;}
        private set {_currentGameState = value; }
    }

    public Difficulty CurrentDifficulty
    {
        get { return _currentDifficulty; }
        private set {_currentDifficulty = value; }
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

    public void UpdateDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        OnDifficultyChange.Invoke(CurrentDifficulty);
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

    public void BeginBackgroundAnimation()
    {
        _backgroundAnimationComponent.Stop();
        _backgroundAnimationComponent.clip = _backgroundAnimation;
        _backgroundAnimationComponent.Play();
    }

    public void StopBackgroundAnimation()
    {
        _backgroundAnimationComponent.Stop();
    }
}
