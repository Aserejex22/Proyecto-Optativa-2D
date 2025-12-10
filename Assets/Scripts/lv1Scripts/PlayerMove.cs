using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Movimiento
    public float moveSpeed = 5f;
    public float jumpSpeed = 12f;

    // Mejoras de salto
    public bool betterJump = true;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 2f;

    // Componentes
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private Rigidbody2D rb2D;
    private float horizontalInput;
    private bool isJumping;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb2D.interpolation = RigidbodyInterpolation2D.Interpolate;

        // Agregar material sin fricción para evitar trabas
        PhysicsMaterial2D noFriction = new PhysicsMaterial2D();
        noFriction.friction = 0f;
        noFriction.bounciness = 0f;
        GetComponent<Collider2D>().sharedMaterial = noFriction;
    }

    private void Update()
    {
        // Capturar input horizontal
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Sistema de salto mejorado
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGround.isGrounded)
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
                isJumping = true;
            }
        }

        // Salto variable - suelta para salto bajo
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            if (rb2D.linearVelocity.y > 0)
            {
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, rb2D.linearVelocity.y * 0.5f);
            }
        }

        // Reset jump flag
        if (CheckGround.isGrounded)
        {
            isJumping = false;
        }

        // Actualizar animaciones
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        // Movimiento horizontal - mantener momentum en el aire
        float targetVelocityX = horizontalInput * moveSpeed;
        rb2D.linearVelocity = new Vector2(targetVelocityX, rb2D.linearVelocity.y);

        // Flip sprite
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Better Jump - gravedad mejorada
        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                // Caída más rápida
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if (rb2D.linearVelocity.y > 0 && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Space))
            {
                // Salto más bajo
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }

    void UpdateAnimations()
    {
        // Animación de correr
        animator.SetBool("Run", Mathf.Abs(horizontalInput) > 0.01f && CheckGround.isGrounded);

        // Animación de salto
        animator.SetBool("Jump", !CheckGround.isGrounded && rb2D.linearVelocity.y > 0);

        // Animación de caída
        animator.SetBool("Falling", !CheckGround.isGrounded && rb2D.linearVelocity.y < 0);
    }
}