using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Vector3 velocity = new Vector3();
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody>();
        ResetBall();
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        ballRb.velocity = velocity;
    }

    Vector3 ReturnRandomVelocity()
    {
        return new Vector3(Random.Range(0,10.0f), 0, Random.Range(0, 10.0f));
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
    }

    public void BeginGame()
    {
        velocity = ReturnRandomVelocity();
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
