using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0,0,-0.25f);

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position - offset;
    }
}
