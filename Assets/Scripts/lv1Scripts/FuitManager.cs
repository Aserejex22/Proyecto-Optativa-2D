using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FuitManager : MonoBehaviour
{
    // public Text levelCleared;
    public Text totalFruits;
    public Text fruitsCollected;

    private int totalFruitsIntLevel;

    void Start()
    {
        totalFruitsIntLevel = transform.childCount;
    }
    public GameObject transition;
    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsIntLevel.ToString();
        
        fruitsCollected.text = (Mathf.Abs(transform.childCount - totalFruitsIntLevel).ToString());

    }
    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            Debug.Log("Nivel Completado");
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
