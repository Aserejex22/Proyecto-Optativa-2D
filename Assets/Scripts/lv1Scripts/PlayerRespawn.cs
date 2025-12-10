using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    private float checkpointX, checkpointY;

    public Animator animator;

    public GameObject [] hearts;

    private int life;

    void Start()
    {
        life = hearts.Length;

        if (PlayerPrefs.GetFloat("checkpointX")!=0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
        }
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("HitAnimation");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("HitAnimation");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("HitAnimation");
        }
    }
    public void ReachedChekpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkpointX", transform.position.x);
        PlayerPrefs.SetFloat("checkpointY", transform.position.y);
    }
    
    public void PlayerDamage()
    {
        life--;
        CheckLife();

    }

    public void PlayerDamageAll()
    {
        life = 0;
        CheckLife();
    }
   
}
