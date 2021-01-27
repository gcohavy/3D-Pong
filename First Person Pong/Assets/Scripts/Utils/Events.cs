using UnityEngine.Events;

public class Events 
{
    [System.Serializable] public class EventGameStateChange : UnityEvent<GameManager.GameState, GameManager.GameState>{}
    [System.Serializable] public class EventDifficultyChange : UnityEvent<GameManager.Difficulty>{}
    //[System.Serializable] public class EventVolumeChange : UnityEvent<float>{}
}
