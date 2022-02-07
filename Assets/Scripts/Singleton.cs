using UnityEngine;

//Used only for Music Player
public class Singleton : MonoBehaviour
{
    public static Singleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
