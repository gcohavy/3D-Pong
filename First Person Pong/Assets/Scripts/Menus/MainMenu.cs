/// <summary>
/// This class serves to Animate the main menu
/// This class has methods to
///     - Begin the title text animation
///     - Slide menu up
///     - Slide menu down
///     - Fade out the menu options
///     - Fade in the menu options
///     - Fade in the about info
///     - Fade out the about info
///     - On animation complete methods
/// </summary>
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //All animations
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _slideUpAnimation;
    [SerializeField] private AnimationClip _slideDownAnimation;
    [SerializeField] private AnimationClip _titleAnimation;
    [SerializeField] private AnimationClip _menuOptionsFadeOutAnimation;
    [SerializeField] private AnimationClip _menuOptionsFadeInAnimation;
    [SerializeField] private AnimationClip _aboutMenuFadeOutAnimation;
    [SerializeField] private AnimationClip _aboutMenuFadeInAnimation;

    //Game objects that need to be activated/deactivated individually
    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private GameObject _aboutMenu;

    //Start runs once before the first frame update
    void Start()
    {
        BeginTitleAnimation();
    }

    //Menu slides up
    public void SlideUp()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _slideUpAnimation;
        _mainMenuAnimation.Play();
    }
    
    //Menu slides down
    public void SlideDown()
    {
        gameObject.SetActive(true);
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _slideDownAnimation;
        _mainMenuAnimation.Play();
    }

    //Menu items fade out
    public void MenuOptionsFadeOut()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _menuOptionsFadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    //Menu items fade in
    public void MenuOptionsFadeIn()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _menuOptionsFadeInAnimation;
        _mainMenuAnimation.Play();
    }

    //About info fades out
    public void AboutMenuFadeOut()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _aboutMenuFadeOutAnimation;
        _mainMenuAnimation.Play();
    }

    //About info fades in
    public void AboutMenuFadeIn()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _aboutMenuFadeInAnimation;
        _mainMenuAnimation.Play();
    }

    //Set main menu to inactive after it slides up
    public void OnSlideUpAnimationComplete()
    {
        //Debug.Log("Slide up complete...");
        gameObject.SetActive(false);
    }
    
    //Animate title text after the menu slides in
    public void OnSlideDownAnimationComplete()
    {
        //Debug.Log("Slide down complete...");
        BeginTitleAnimation();
    }

    //Deactivate the buttons on the main menu after they fade out
    // and fade in the about info
    public void OnMenuOptionsFadeOutComplete()
    {
        _menuOptions.gameObject.SetActive(false);
        AboutMenuFadeIn();
    }

    //Animate title text after menu items fade in
    public void OnMenuOptionsFadeInComplete()
    {
        //possibly do something once the menu is back
        BeginTitleAnimation();
    }

    //Set the about menu items to inactive after they fade out
    // and begin the main menu buttons fade in animation 
    public void OnAboutMenuFadeOutComplete()
    {
        _aboutMenu.gameObject.SetActive(false);
        MenuOptionsFadeIn();
    }

    //Begin the title text animation once the about menu finishes fading in
    public void OnAboutMenuFadeInComplete()
    {
        //Possibly do something
        BeginTitleAnimation();
    }

    //method to start the title text animation
    private void BeginTitleAnimation()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _titleAnimation;
        _mainMenuAnimation.Play();
    }
}
