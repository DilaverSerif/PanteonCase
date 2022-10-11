using UnityEngine;

public abstract class Singlenton<T>: MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
            }
            
            return _instance;
        }
    }
    
    protected static T _instance;
}
