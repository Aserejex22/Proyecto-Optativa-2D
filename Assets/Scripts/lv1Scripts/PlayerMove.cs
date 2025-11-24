using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(moveSpeed, rb2D.linearVelocity.y);
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-moveSpeed, rb2D.linearVelocity.y);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
        }
        if((Input.GetKey("space") || Input.GetKey("up")) && CheckGround.isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        if (betterJump)
        {
            if(rb2D.linearVelocity.y < 0)
            {
               rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
               rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
