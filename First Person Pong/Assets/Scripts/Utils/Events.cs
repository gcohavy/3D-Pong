/// <summary>
/// This class serves to put all Game events in a single class
/// This would be more useful if the game needed to be bigger, but for now it
///  is just a good habit
/// </summary>

using UnityEngine.Events;

public class Events 
{
    [System.Serializable] public class EventGameStateChange : UnityEvent<GameManager.GameState, GameManager.GameState>{}
    [System.Serializable] public class EventDifficultyChange : UnityEvent<GameManager.Difficulty>{}
    //[System.Serializable] public class EventVolumeChange : UnityEvent<float>{}
}
