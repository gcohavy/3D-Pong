using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 velocity = new Vector3();
    private Rigidbody ballRb;
    private float zBoundaries = 10;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
        ResetBall();
        MoveBall();
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

    Vector3 ReturnRandomVelocity()
    {
        return new Vector3(Random.Range(0,10.0f), 0, Random.Range(0, 10.0f));
    }

    public void ResetBall()
    {
        velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    public void MoveBall()
    {
        velocity = ReturnRandomVelocity();
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "PlayerPaddle": 
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
}
