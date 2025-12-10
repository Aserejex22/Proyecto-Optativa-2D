using UnityEngine;

public class AudioPersistence : MonoBehaviour
{
    private void Awake()
    {
        int count = FindObjectsOfType<AudioPersistence>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}