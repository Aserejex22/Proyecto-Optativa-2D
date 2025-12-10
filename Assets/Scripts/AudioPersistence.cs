using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPersistence : MonoBehaviour
{
    private const string MenuSceneName = "MenuMain";
    private const string CreditsSceneName = "EndCredits";

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        if (sceneName == MenuSceneName || sceneName == CreditsSceneName)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}