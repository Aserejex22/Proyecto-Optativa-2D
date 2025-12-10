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
        Time.timeScale = 1; 
        GameObject levelMusic = GameObject.Find("LevelMusicSource");
        if (levelMusic != null)
        {
            Destroy(levelMusic);
            Debug.Log("Música persistente del nivel destruida.");
        }
        
        SceneManager.LoadScene("MenuMain"); 
        
        Debug.Log("Volviendo al menú principal...");
    }
}