using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Asegúrate de que estos están arrastrados en el Inspector
    public GameObject mainMenuPanel; 
    public GameObject creditsPanel; 

    // <<<< NUEVA LÍNEA PARA LA MÚSICA >>>>
    public AudioSource creditsAudioSource; 

    void Start()
    {
        // 1. ACTIVACIÓN INICIAL: Al cargar la escena, activa el panel de botones.
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
        
        // 2. Desactiva el panel de créditos para que no bloquee.
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
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

    // --- TUS FUNCIONES DE CRÉDITOS ---

    public void OpenCredits()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        
        // <<<< AHORA REPRODUCIMOS LA MÚSICA >>>>
        if (creditsAudioSource != null)
        {
            creditsAudioSource.Play();
        }
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        
        // <<<< DETENEMOS LA MÚSICA AL CERRAR >>>>
        if (creditsAudioSource != null)
        {
            creditsAudioSource.Stop();
        }
    }
}