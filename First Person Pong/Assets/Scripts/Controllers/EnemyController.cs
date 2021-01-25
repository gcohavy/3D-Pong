using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject gameBall;
    Rigidbody ballRb;
    public float speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        gameBall = GameObject.Find("Ball");
        ballRb = gameBall.GetComponent<Rigidbody>();

        GameManager.Instance.OnDifficultyChange.AddListener(HandleDifficultyChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(ballRb.velocity.z < 0){
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
