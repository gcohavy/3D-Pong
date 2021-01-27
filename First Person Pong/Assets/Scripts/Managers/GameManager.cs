/// <summary>
/// This class serves to keep track of GameState and Difficulty
/// potential to expand it to keep track of W/L record or to load different levels
/// for now there is only one level so things are not currently made to be expanded
/// This class contains methods for:
///     - Playing the different background musics
///     - Starting the background animation
///     - Stopping the background animation
///     - Changing the current Difficulty
///     - changing the current GameState
///     - Setting the backgroud music volume
/// </summary>
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Keep track of GameState
    public enum GameState
    {
        PREGAME,
        RUNNING,
        GAMEOVER
    }

    //Keep track of difficulty
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }

    GameState _currentGameState = GameState.PREGAME;
    Difficulty _currentDifficulty = Difficulty.MEDIUM;

    //Get sound variables
    //Note that if there were multiple environments built this would not be in the GameManager
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _inGameMusic;
    [SerializeField] private AudioClip _gameOverMusic;

    //Get background animation. 
    //Note that if there were multiple environments built this would not be in the GameManager
    [SerializeField] private Animation _backgroundAnimationComponent;
    [SerializeField] private AnimationClip _backgroundAnimation;

    //Events for GameState and Difficulty 
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

    //Start is called before the first frame
    void Start()
    {
        PlayMainMenuMusic();
    }

    //Public method to update state
    public void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        CurrentGameState = state;

        OnGameStateChange.Invoke(CurrentGameState, previousGameState);

        //Play the Game Over music
        if(CurrentGameState == GameState.GAMEOVER && previousGameState == GameState.RUNNING)
        {
            PlayGameOverMusic();
        }
    }

    //Public method to update difficulty
    public void UpdateDifficulty(Difficulty difficulty)
    {
        CurrentDifficulty = difficulty;
        OnDifficultyChange.Invoke(CurrentDifficulty);
    }

    //override the singleton OnDestroy method
/*    protected override void OnDestroy()
    {
        base.OnDestroy();

        //potentially do some logic if the GameManager is destroyed, like unloading scenes
        //This method is here to be expanded
    }
*/

    //Play calm main menu music
    public void PlayMainMenuMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _mainMenuMusic;
        _backgroundMusicSource.Play();
    }

    //play intense playtime music
    public void PlayInGameMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _inGameMusic;
        _backgroundMusicSource.Play();
    }

    //play calm game over music
    public void PlayGameOverMusic()
    {
        _backgroundMusicSource.Stop();
        _backgroundMusicSource.clip = _gameOverMusic;
        _backgroundMusicSource.Play();
    }

    //Animate background 
    public void BeginBackgroundAnimation()
    {
        _backgroundAnimationComponent.Stop();
        _backgroundAnimationComponent.clip = _backgroundAnimation;
        _backgroundAnimationComponent.Play();
    }

    //Pause background animation during main menu
    public void StopBackgroundAnimation()
    {
        _backgroundAnimationComponent.Stop();
    }

    //Set music volume
    public void SetVolume(float value)
    {
        _backgroundMusicSource.volume = value;
    }
}
