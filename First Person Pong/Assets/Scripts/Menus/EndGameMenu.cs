using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _winnerText;

    public void GameWon()
    {
        GameOver();
        _winnerText.gameObject.SetActive(true);
    }

    public void GameLost()
    {
        GameOver();
        _gameOverText.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        gameObject.SetActive(true);
    }
}
