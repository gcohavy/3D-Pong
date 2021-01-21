using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _slideUpAnimation;
    [SerializeField] private AnimationClip _slideDownAnimation;
    [SerializeField] private AnimationClip _titleAnimation;

    void Start()
    {
        BeginTitleAnimation();
    }

    public void SlideUp()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _slideUpAnimation;
        _mainMenuAnimation.Play();
    }
    
    public void SlideDown()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _slideDownAnimation;
        _mainMenuAnimation.Play();
    }

    public void OnSlideUpAnimationComplete()
    {
        Debug.Log("Slide up complete...");
    }
    
    public void OnSlideDownAnimationComplete()
    {
        Debug.Log("Slide down complete...");
        BeginTitleAnimation();
    }

    private void BeginTitleAnimation()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _titleAnimation;
        _mainMenuAnimation.Play();
    }
}
