using UnityEngine;
using UnityEngine.SceneManagement; // <-- ¡OJO! Esta línea es obligatoria para cargar niveles

public class MainMenuManager : MonoBehaviour
{
    // Asegúrate de que estos están arrastrados en el Inspector
    public GameObject mainMenuPanel; 
    public GameObject creditsPanel; 

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
        // Asegúrate de que tu escena se llame EXACTAMENTE "lvl1" (minúsculas importan).
        SceneManager.LoadScene("lvl1"); 
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Esto es para que veas que funciona en el editor
        Application.Quit();
    }

    // --- TUS FUNCIONES DE CRÉDITOS (IGUAL QUE ANTES) ---

    public void OpenCredits()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }
}