using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _slideUpAnimation;
    [SerializeField] private AnimationClip _slideDownAnimation;
    [SerializeField] private AnimationClip _titleAnimation;
    [SerializeField] private AnimationClip _menuOptionsFadeOutAnimation;
    [SerializeField] private AnimationClip _menuOptionsFadeInAnimation;
    [SerializeField] private AnimationClip _aboutMenuFadeOutAnimation;
    [SerializeField] private AnimationClip _aboutMenuFadeInAnimation;

    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private GameObject _aboutMenu;

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
        gameObject.SetActive(true);
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _slideDownAnimation;
        _mainMenuAnimation.Play();
    }

    public void MenuOptionsFadeOut()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _menuOptionsFadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    public void MenuOptionsFadeIn()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _menuOptionsFadeInAnimation;
        _mainMenuAnimation.Play();
    }

    public void AboutMenuFadeOut()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _aboutMenuFadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    public void AboutMenuFadeIn()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _aboutMenuFadeInAnimation;
        _mainMenuAnimation.Play();
    }

    public void OnSlideUpAnimationComplete()
    {
        Debug.Log("Slide up complete...");
        gameObject.SetActive(false);
    }
    
    public void OnSlideDownAnimationComplete()
    {
        Debug.Log("Slide down complete...");
        BeginTitleAnimation();
    }

    public void OnMenuOptionsFadeOutComplete()
    {
        _menuOptions.gameObject.SetActive(false);
        AboutMenuFadeIn();
    }

    public void OnMenuOptionsFadeInComplete()
    {
        //possibly do something once the menu is back
        BeginTitleAnimation();
    }

    public void OnAboutMenuFadeOutComplete()
    {
        _aboutMenu.gameObject.SetActive(false);
        MenuOptionsFadeIn();
    }

    public void OnAboutMenuFadeInComplete()
    {
        //Possibly do something
        BeginTitleAnimation();
    }

    private void BeginTitleAnimation()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _titleAnimation;
        _mainMenuAnimation.Play();
    }
}
