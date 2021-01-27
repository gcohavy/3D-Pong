/// <summary>
/// This class serves to control the player paddle
/// the player paddle must:
///     - Be contained within the boundaries
///     - Move along the X-Axis based on player input
///     - Adjust in size based on difficulty
///     - Only be able to move while GameState is RUNNING
/// </summary>
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declare variables
    private float speed = 15;
    private float xBound = 5.5f;
    //Store starting position because menu canvases are in world space
    private Vector3 startingPosition = new Vector3 (0,0,10);

    // Start is called before the first frame
    void Start()
    {
        //Handle GameState and Difficulty changes
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        GameManager.Instance.OnDifficultyChange.AddListener(HandleDifficultyChange);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the paddle based on player input while the GameState is RUNNING
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);

            if(transform.position.x > xBound)
            {
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < -xBound)
            {
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            }
        }
        
    }

    //Reset position of player on gamestate going back to RUNNING
    //Note that this will be a bug if the player loses or wins and theyre not in the middle
    // this will cause the GameOverCanvas to be off center
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(previousState == GameManager.GameState.GAMEOVER && currentState == GameManager.GameState.PREGAME)
        {
            transform.position = startingPosition;
        }
    }

    //Adjust player size based on difficulty, so that it is more forgiving on lower difficulty
    void HandleDifficultyChange(GameManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case GameManager.Difficulty.EASY:
                transform.localScale = new Vector3(3, 1 , 0.5f);
                break;
            case GameManager.Difficulty.MEDIUM:
                transform.localScale = new Vector3(2.5f, 1 , 0.5f);
                break;
            case GameManager.Difficulty.HARD:
                transform.localScale = new Vector3(2, 1 , 0.5f);
                break;
            default:
                break;
        }
    }
}
