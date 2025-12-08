using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
   public void QuitGame()
    {
        // 1. Asegúrate de que el tiempo corra normal
        Time.timeScale = 1; 

        // 2. ¡La clave! Carga la escena del menú principal
        //    Asegúrate de que tu escena de menú se llame EXACTAMENTE "MenuMain"
        SceneManager.LoadScene("MenuMain"); 
        
        Debug.Log("Volviendo al menú principal...");
    }
}    