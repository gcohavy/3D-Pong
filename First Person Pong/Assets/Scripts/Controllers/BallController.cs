using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioSource soundsPlayer;
    private float startTimeAudio = 0.3f;

    private Vector3 velocity = new Vector3(0,0,0);
    private Rigidbody ballRb;
    private float zBoundaries = 10;
    public float speedStepUp = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();

        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
        GameManager.Instance.OnDifficultyChange.AddListener(HandleDifficultyChange);

        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        ballRb.velocity = velocity;

        if(transform.position.z > zBoundaries)
        {
            Debug.Log("> than z boundary");
            GameManager.Instance.UpdateState(GameManager.GameState.GAMEOVER);
            ResetBall();
        }
        if(transform.position.z < -zBoundaries)
        {
            Debug.Log("< z Boundary");
            GameManager.Instance.UpdateState(GameManager.GameState.GAMEOVER);
            ResetBall();
        }
    }

    public void ResetBall()
    {
        velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    public void MoveBall()
    {
        velocity = new Vector3(Random.Range(0,5.0f), 0, Random.Range(5, 10.0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        soundsPlayer.time= startTimeAudio;
        soundsPlayer.Play();

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

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.RUNNING)
        {
            MoveBall();
        }
    }

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
