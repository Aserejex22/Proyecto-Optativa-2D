using UnityEngine;

public class Sword : MonoBehaviour
{

    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D collider2D;

    public Animator animator;

    public GameObject swordParent;

    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (playerSpriteRenderer.flipX == true)
        {
            swordParent.transform.localPosition = new Vector3(-0.5f, swordParent.transform.localPosition.y, swordParent.transform.localPosition.z);
            collider2D.offset = new Vector2(-Mathf.Abs(collider2D.offset.x), collider2D.offset.y);
        }
        else
        {
            swordParent.transform.localPosition = new Vector3(0.5f, swordParent.transform.localPosition.y, swordParent.transform.localPosition.z);
            collider2D.offset = new Vector2(Mathf.Abs(collider2D.offset.x), collider2D.offset.y);
        }

    }

    public void Attack()
    {
        animator.Play("Attack");
        collider2D.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }

    private void DisableAttack()
    {
        collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LosseLifeAndHit();
            collider2D.enabled = false;
        }
    }
}
