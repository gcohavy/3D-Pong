/// <summary>
/// This class serves to manage the game start animations
/// It must listen for 'SPACE' keypress and begin a countdown animation
/// </summary>

using UnityEngine;

public class PregameMenu : MonoBehaviour
{
    [SerializeField] private Animation _pregameAnimation;
    [SerializeField] private AnimationClip _countdown;
    [SerializeField] private UnityEngine.UI.Button _beginButton;

    //Update is called every frame
    void Update()
    {
        //Begin countdown if Space is pressed
        //Potential bug if the user presses SPACE multiple times, but I will leave that for now
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Countdown beginning...");
            BeginCountdown();
        }
    }

    //Get rid of the button and begin the countdown animation
    public void BeginCountdown()
    {
        _beginButton.gameObject.SetActive(false);
        _pregameAnimation.Stop();
        _pregameAnimation.clip = _countdown;
        _pregameAnimation.Play();
    }

    //Set the Game Object to inactive so that it does not keep running the update method
    //Set GameState to RUNNING so player can start moving
    public void OnCountdownAnimationComplete()
    {
        gameObject.SetActive(false);
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }

    //public method to set the menu items back to active
    public void SetBackToActive()
    {
        gameObject.SetActive(true);
        _beginButton.gameObject.SetActive(true);
    }
}
