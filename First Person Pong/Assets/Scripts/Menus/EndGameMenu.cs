/// <summary>
/// This class serves to play end game music and load the endGame menu based on w/L
/// </summary>
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    //Store Win/Loss variables
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _winnerText;

    //Store Sounds
    [SerializeField] private AudioSource _endGameAudioListener;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _youWonSound;

    //Game won functionality
    public void GameWon()
    {
        GameOver();
        _endGameAudioListener.clip = _youWonSound;
        _endGameAudioListener.Play();
        _winnerText.gameObject.SetActive(true);
    }

    //Game Lost functionality
    public void GameLost()
    {
        GameOver();
        _endGameAudioListener.clip = _gameOverSound;
        _endGameAudioListener.Play();
        _gameOverText.gameObject.SetActive(true);
    }

    //Consolidated code shared between Win/Loss
    private void GameOver()
    {
        gameObject.SetActive(true);
        GameManager.Instance.UpdateState(GameManager.GameState.GAMEOVER);
        _endGameAudioListener.Stop();
    }

    //Set everything back to Inactive
    public void ResetInactive()
    {
        _gameOverText.gameObject.SetActive(false);
        _winnerText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
