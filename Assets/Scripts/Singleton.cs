using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance = null;

    void Awake()
    {
        if (instance != null && instance != this.gameObject) Destroy(this.gameObject);
        else instance = this.gameObject as T;
        DontDestroyOnLoad(this);
    }
}
