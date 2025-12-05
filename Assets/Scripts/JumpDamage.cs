using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D collider2D;
    public float jumpForce = 2.5f;

    public int lifes = 13;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * jumpForce);
            LosseLifeAndHit();
        }
    }

    public void LosseLifeAndHit()
    {
        lifes--;
        CheckLife();
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            Destroy(gameObject);
        }
    }
}