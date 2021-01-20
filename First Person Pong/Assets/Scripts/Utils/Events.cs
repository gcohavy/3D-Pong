using UnityEngine.Events;

public class Events 
{
    [System.Serializable] public class EventGameStateChange : UnityEvent<GameManager.GameState, GameManager.GameState>{}
}
