/// <summary>
/// This class serves to control the ball movements as it 
/// collides with the environment and the paddles
/// The ball must:
///     - Move when the player wants to start 
///     - Bounce off of Environment
///     - Register when game is over
///     - Accelerate every time it hits the player paddle
///     - Adjust itself based on selected difficulty
///     - Play a collision sound when it hits something
/// </summary>

using UnityEngine;

public class BallController : MonoBehaviour
{
    //Get the audio variables
    [SerializeField] private AudioSource soundsPlayer;
    private float startTimeAudio = 0.3f;

    //Keep track of velocity for every frame update so there is no slowdown
    private Vector3 velocity = new Vector3(0,0,0);
    private Rigidbody ballRb;
    private float zBoundaries = 10;
    public float speedStepUp = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody for the velocity variable
        ballRb = gameObject.GetComponent<Rigidbody>();

        //Respond to Game State and Difficulty changes
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        GameManager.Instance.OnDifficultyChange.AddListener(HandleDifficultyChange);

        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the velocity every frame
        ballRb.velocity = velocity;

        //Check for game over (this could have probably been consolidated but I was lazy)
        if(transform.position.z > zBoundaries)
        {
            UIManager.Instance.GameOver(false);
            ResetBall();
        }
        if(transform.position.z < -zBoundaries)
        {
            UIManager.Instance.GameOver(true);
            ResetBall();
        }
    }

    //Method to bring the ball back to the center
    public void ResetBall()
    {
        velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    //Start the ball movement at a rendom speed and direction towards the player
    public void MoveBall()
    {
        velocity = new Vector3(Random.Range(0,5.0f), 0, Random.Range(5, 10.0f));
    }

    //Handle collisions
    void OnCollisionEnter(Collision collision)
    {
        //Play sound
        soundsPlayer.time= startTimeAudio;
        soundsPlayer.Play();

        //Bounce off and accelerate depending on what it collided with
        switch (collision.gameObject.name)
        {
            case "PlayerPaddle": 
                velocity.z += velocity.z > 0 ? speedStepUp : -speedStepUp;
                velocity.x += velocity.x > 0 ? speedStepUp : -speedStepUp;
                velocity.z = -velocity.z;
                break;
            case "EnemyPaddle":
                velocity.z = -velocity.z;
                break;
            case "BorderL":
            case "BorderR":
                velocity.x = -velocity.x;
                break;
            default:
                break;
        }
    }

    //Move the ball of the GameState was changed to RUNNING
    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            MoveBall();
        }
    }

    //Adjust the ball based on difficulty
    void HandleDifficultyChange(GameManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case GameManager.Difficulty.EASY:
                speedStepUp = 0.1f;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                break;
            case GameManager.Difficulty.MEDIUM:
                speedStepUp = 0.5f;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case GameManager.Difficulty.HARD:
                speedStepUp = 0.7f;
                transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                break;
            default:
                break;
        }
    }
}
