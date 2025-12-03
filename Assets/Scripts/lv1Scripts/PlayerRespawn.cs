using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    private float checkpointX, checkpointY;

    public Animator animator;

    void Start()
    {
        if (PlayerPrefs.GetFloat("checkpointX")!=0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
        }
    }

    public void ReachedChekpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkpointX", transform.position.x);
        PlayerPrefs.SetFloat("checkpointY", transform.position.y);
    }
    
    public void PlayerDamage()
    {
        animator.Play("HitAnimation");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
   
}
