using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FuitManager : MonoBehaviour
{   
   // public Text levelCleared;

    public GameObject transition;
    private void Update()
    {
        AllFruitsCollected();

    }
    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("Nivel Completado");
           // levelCleared.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
