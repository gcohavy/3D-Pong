using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject gameBall;
    Rigidbody ballRb;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameBall = GameObject.Find("Ball");
        ballRb = gameBall.GetComponent<Rigidbody>();
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
}
