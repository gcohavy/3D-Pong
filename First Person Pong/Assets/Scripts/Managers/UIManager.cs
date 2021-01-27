/// <summary>
/// This class serves to manage all the different menus and how they should animate
///  and appear according to input
/// This class will also serve for every method associated with any button in a Menu
/// </summary>
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    //Get references to all menus
    [SerializeField] private EndGameMenu _endGameMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private OptionsMenu _optionsMenu;
    [SerializeField] private PregameMenu _pregameMenu;

    //Get reference to volume slider
    [SerializeField] private UnityEngine.UI.Slider _volumeSlider;

    //Events.EventVolumeChange OnVolumeChanged;

    void Start()
    {
        //Subscribe to the State Change event
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    //Handle Game over
    public void GameOver(bool won)
    {
        if(won) _endGameMenu.GameWon();
        else _endGameMenu.GameLost();
    }

    //Deactivate the pregame menu if the GameState was changed to RUNNING
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
        //Set the Pregame Menu to active and Move the Main Menu out of the way
        //Debug.Log("Animation being called...");
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
        //Since this is not an actual application, this serves as more of a placeholder
        Application.Quit();
    }

    //Options Menu
    public void BackButton()
    {
        _optionsMenu.SlideOut();
    }

    public void SetVolume()
    {
        //OnVolumeChanged.Invoke(value);
        GameManager.Instance.SetVolume(_volumeSlider.value);
    }

    //--Difficulty buttons--
    //These could be consolidated
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
    ///* No longer supposed to be clicked but ok to leave functionality
    public void BeginButton()
    {
        _pregameMenu.BeginCountdown();
    }
    //*/

    //EndgameMenu
    public void RestartButton()
    {
        //Bring the player back to the pregame screen
        _pregameMenu.SetBackToActive();
        _endGameMenu.ResetInactive();
        GameManager.Instance.PlayInGameMusic();
        GameManager.Instance.UpdateState(GameManager.GameState.PREGAME);
    }

    public void ExitToMainButton()
    {
        //Reset the game back to its menu state
        //Note that on a larger scale, this method would need to be rewritten
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
