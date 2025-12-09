using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private const string MenuSceneName = "MenuMain";
    private const string CreditsSceneName = "EndCredits";

    // Asegurate de arrastrar estas referencias en el Inspector
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;

    // Musica para los creditos
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

    // --- NUEVAS FUNCIONES PARA JUGAR Y SALIR ---

    public void Jugar()
    {
        // Carga la escena llamada "lvl1".
        SceneManager.LoadScene("lvl1");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Esto es para que veas que funciona en el editor
        Application.Quit();
    }

    // --- TUS FUNCIONES DE CREDITOS ---

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

        // <<<< AHORA REPRODUCIMOS LA MUSICA >>>>
        if (creditsAudioSource != null)
        {
            creditsAudioSource.Play();
        }
    }

    public void CloseCredits()
    {
        // En la escena dedicada de creditos volvemos al menu principal.
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
        
        // <<<< DETENEMOS LA MUSICA AL CERRAR >>>>
        if (creditsAudioSource != null)
        {
            creditsAudioSource.Stop();
        }
    }
}
