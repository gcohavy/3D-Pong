/// <summary>
/// This class serves to control the camera so that it stays with the player
///
/// </summary>

using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Get the player object and set an offset
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0,0,0.25f);
    Vector3 originalPosition = new Vector3(0,0,10.25f);

    //Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateChange.AddListener(HandleGameStateChange);
    }

    // Update is called once per frame
    void Update()
    {
        //Keep the camera at Player's position while GameState is RUNNING
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.RUNNING)
        {
            transform.position = player.transform.position + offset;
        }
        
    }

    public void OnPregameAnimationComplete()
    {
        //Debug.Log("context animation complete...");
        UIManager.Instance.SetPregameMenuActive();
    }

    void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.PREGAME && previousState == GameManager.GameState.GAMEOVER)
        {
            transform.position = originalPosition;
        }
    }
}
