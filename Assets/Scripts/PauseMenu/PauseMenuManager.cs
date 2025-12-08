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
        // Esto reinicia el nivel actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    
    public void QuitGame()
    {
        // 1. Asegúrate de que el tiempo corra normal
        Time.timeScale = 1; 

        // <<<< NUEVO: BUSCAR Y DESTRUIR LA MÚSICA PERSISTENTE >>>>
        
        // Asumimos que el objeto de música persistente se llama "LevelMusicSource"
        GameObject levelMusic = GameObject.Find("LevelMusicSource");
        if (levelMusic != null)
        {
            Destroy(levelMusic);
            Debug.Log("Música persistente del nivel destruida.");
        }
        
        // <<<< FIN DE LA LIMPIEZA >>>>

        // 2. Carga la escena del menú principal
        SceneManager.LoadScene("MenuMain"); 
        
        Debug.Log("Volviendo al menú principal...");
    }
}