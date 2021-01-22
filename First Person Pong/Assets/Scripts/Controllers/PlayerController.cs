using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 12;
    private float xBound = 5.5f;

    // Update is called once per frame
    void Update()
    {
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
}
