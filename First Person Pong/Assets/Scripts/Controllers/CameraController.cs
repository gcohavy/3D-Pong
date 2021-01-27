/// <summary>
/// This class serves to control the camera so that it stays with the player
/// </summary>

using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Get the player object and set an offset
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0,0,-0.25f);

    // Update is called once per frame
    void Update()
    {
        //Keep the camera at Player's position
        gameObject.transform.position = player.transform.position - offset;
    }
}
