/// <summary>
/// This class serves to control the enemy AI
/// The enemy paddle must:
///     - Follow the ball with a delay
///     - Adjust its speed based on difficulty
/// </summary>
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Store references to the ball 
    GameObject gameBall;
    Rigidbody ballRb;
    //Set a default speed
    public float speed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Find the ball in the scene
        gameBall = GameObject.Find("Ball");
        ballRb = gameBall.GetComponent<Rigidbody>();

        //Handle a difficulty change
        GameManager.Instance.OnDifficultyChange.AddListener(HandleDifficultyChange);
    }

    // Update is called once per frame
    void Update()
    {
        //Only move if the ball is going towards the enemy paddle
        //This provides an illusion that it is reacting
        if(ballRb.velocity.z < 0){
            //Move in the direction of the ball at the given speed
            if(gameBall.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else if(gameBall.transform.position.x > transform.position.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }
    }

    //Adjust enemy paddle speed based on difficulty
    void HandleDifficultyChange(GameManager.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case GameManager.Difficulty.EASY:
                speed = 4;
                break;
            case GameManager.Difficulty.MEDIUM:
                speed = 5;
                break;
            case GameManager.Difficulty.HARD:
                speed = 7.5f;;
                break;
            default:
                break;
        }
    }
}
