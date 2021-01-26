using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _winnerText;

    [SerializeField] private AudioSource _endGameAudioListener;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _youWonSound;

    public void GameWon()
    {
        GameOver();
        _endGameAudioListener.Stop();
        _endGameAudioListener.clip = _youWonSound;
        _endGameAudioListener.Play();
        _winnerText.gameObject.SetActive(true);
    }

    public void GameLost()
    {
        GameOver();
        _endGameAudioListener.Stop();
        _endGameAudioListener.clip = _gameOverSound;
        _endGameAudioListener.Play();
        _gameOverText.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        gameObject.SetActive(true);
        GameManager.Instance.UpdateState(GameManager.GameState.GAMEOVER);
    }

    public void ResetInactive()
    {
        _gameOverText.gameObject.SetActive(false);
        _winnerText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
