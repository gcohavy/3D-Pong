using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance 
    {
        get { return _instance;}
    }

    public static bool IsInitialized()
    {
        return _instance != null;
    }

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            _instance = (T) this;
        }
        else
        {
            Debug.LogError("[Singleton] Cannot create multiple instances of " + _instance);
        }
    }

    protected virtual void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }
}
