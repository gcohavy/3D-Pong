/// <summary>
/// This class serves to manage the options menu animations
/// </summary>

using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    //Get references to animation variables
    [SerializeField] private Animation _optionsMenuAnimation;
    [SerializeField] private AnimationClip _slideInAnimation;
    [SerializeField] private AnimationClip _slideOutAnimation;

    //Set the options menu to active and slide it in
    public void SlideIn()
    {
        gameObject.SetActive(true);
        _optionsMenuAnimation.Stop();
        _optionsMenuAnimation.clip = _slideInAnimation;
        _optionsMenuAnimation.Play();
    }
    
    //Slide out the options menu
    public void SlideOut()
    {
        _optionsMenuAnimation.Stop();
        _optionsMenuAnimation.clip = _slideOutAnimation;
        _optionsMenuAnimation.Play();
    }

    //Currently does nothing after the menu finishes sliding in
    public void OnSlideInAnimationComplete()
    {
        //Debug.Log("Slide in complete...");
        //Possibly begin an options menu background animation, or sound
    }

    // Set the options menu to inactive after it finishes sliding out
    public void OnSlideOutAnimationComplete()
    {
        //Debug.Log("Slide out complete...");
        gameObject.SetActive(false);
    }
}
