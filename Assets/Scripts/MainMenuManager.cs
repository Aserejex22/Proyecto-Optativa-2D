using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private const string MenuSceneName = "MenuMain";
    private const string CreditsSceneName = "EndCredits";

    public GameObject mainMenuPanel;
    public GameObject creditsPanel;

    public AudioSource creditsAudioSource;

    void Start()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        bool isMenuScene = activeSceneName == MenuSceneName;
        bool isCreditsScene = activeSceneName == CreditsSceneName;

        if (isMenuScene && mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }

        if (isMenuScene && creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }
        else if (isCreditsScene && creditsPanel != null)
        {
            creditsPanel.SetActive(true);
            if (creditsAudioSource != null && !creditsAudioSource.isPlaying)
            {
                creditsAudioSource.Play();
            }
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }


    public void OpenCredits()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }

        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }
        if (creditsAudioSource != null)
        {
            creditsAudioSource.Play();
        }
    }

    public void CloseCredits()
    {
        if (SceneManager.GetActiveScene().name == CreditsSceneName)
        {
            Time.timeScale = 1f;

            if (creditsAudioSource != null)
            {
                creditsAudioSource.Stop();
            }

            SceneManager.LoadScene(MenuSceneName);
            return;
        }

        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }

        if (creditsAudioSource != null)
        {
            creditsAudioSource.Stop();
        }
    }
}
