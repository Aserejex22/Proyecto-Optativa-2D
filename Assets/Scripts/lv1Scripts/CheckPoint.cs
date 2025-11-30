using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedChekpoint(transform.position.x, transform.position.y);
            GetComponent<Animator>().enabled = true;

        }
    }
}
