using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] hearts;

    private int life;
    private const string CHECKPOINT_X_KEY = "checkpointX";
    private const string CHECKPOINT_Y_KEY = "checkpointY";

    void Start()
    {
        life = hearts.Length;

        float checkpointX = PlayerPrefs.GetFloat(CHECKPOINT_X_KEY, 0f);
        float checkpointY = PlayerPrefs.GetFloat(CHECKPOINT_Y_KEY, 0f);

        if (checkpointX != 0 || checkpointY != 0)
        {
            transform.position = new Vector2(checkpointX, checkpointY);
        }
    }

    private void CheckLife()
    {
        if (life <= 0)
        {
            if (hearts.Length > 0 && hearts[0] != null)
                Destroy(hearts[0].gameObject);
            animator.Play("HitAnimation");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life == 1 && hearts.Length > 1 && hearts[1] != null)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("HitAnimation");
        }
        else if (life == 2 && hearts.Length > 2 && hearts[2] != null)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("HitAnimation");
        }
    }

    public void ReachedChekpoint(float x, float y)
    {
        PlayerPrefs.SetFloat(CHECKPOINT_X_KEY, x);
        PlayerPrefs.SetFloat(CHECKPOINT_Y_KEY, y);
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