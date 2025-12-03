using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKey("w") || Input.GetKey("up")))
        {
            if (CheckGround.isGrounded)
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            }
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else if (rb2D.linearVelocity.y > 0)
        {
            animator.SetBool("Falling", false);

        }
    }
        void FixedUpdate()
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb2D.linearVelocity = new Vector2(moveSpeed, rb2D.linearVelocity.y);
                spriteRenderer.flipX = false;
                animator.SetBool("Run", true);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2D.linearVelocity = new Vector2(-moveSpeed, rb2D.linearVelocity.y);
                spriteRenderer.flipX = true;
                animator.SetBool("Run", true);
            }
            else
            {
                rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
                animator.SetBool("Run", false);
            }


            if (betterJump)
            {
                if (rb2D.linearVelocity.y < 0)
                {
                    rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
                }
                if (rb2D.linearVelocity.y > 0 && !Input.GetKey("w"))
                {
                    rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
                }
            }
        }
    }
