using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PregameMenu : MonoBehaviour
{
    [SerializeField] private Animation _pregameAnimation;
    [SerializeField] private AnimationClip _countdown;
    [SerializeField] private Button _beginButton;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Countdown beginning...");
            BeginCountdown();
        }
    }

    public void BeginCountdown()
    {
        _beginButton.gameObject.SetActive(false);
        _pregameAnimation.Stop();
        _pregameAnimation.clip = _countdown;
        _pregameAnimation.Play();
    }

    public void OnCountdownAnimationComplete()
    {
        gameObject.SetActive(false);
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }

    public void SetBackToActive()
    {
        gameObject.SetActive(true);
        _beginButton.gameObject.SetActive(true);
    }
}
