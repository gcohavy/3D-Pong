using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Animation _optionsMenuAnimation;
    [SerializeField] private AnimationClip _slideInAnimation;
    [SerializeField] private AnimationClip _slideOutAnimation;

    public void SlideIn()
    {
        gameObject.SetActive(true);
        _optionsMenuAnimation.Stop();
        _optionsMenuAnimation.clip = _slideInAnimation;
        _optionsMenuAnimation.Play();
    }
    
    public void SlideOut()
    {
        _optionsMenuAnimation.Stop();
        _optionsMenuAnimation.clip = _slideOutAnimation;
        _optionsMenuAnimation.Play();
    }

    public void OnSlideInAnimationComplete()
    {
        Debug.Log("Slide in complete...");
        //fire event for main menu to deactivate
    }

    public void OnSlideOutAnimationComplete()
    {
        Debug.Log("Slide out complete...");
        gameObject.SetActive(false);
    }
}
