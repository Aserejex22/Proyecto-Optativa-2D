using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
// Controla el movimiento del jugador escuchando eventos de input.
public class PlayerMovementEvents : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 10f;

    [Header("Ground check")]
    public float groundCheckRadius = 0.12f;
    public LayerMask groundLayer; // setea la Layer del suelo en el Inspector (si está vacío intenta "Ground" o Everything)

    [Header("Limiters")]
    public float maxUpwardSpeed = 12f; // evita velocidades verticales excesivas (por colisiones)

    Rigidbody2D rb;
    Collider2D col;
    float moveInput;
    bool jumpRequested;
    bool canJump = true; // solo permitir un salto hasta volver al suelo

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        // Si el usuario no configuró un LayerMask en el Inspector, intenta usar la Layer "Ground".
        if (groundLayer.value == 0)
        {
            int mask = LayerMask.GetMask("Ground");
            if (mask != 0) groundLayer = mask;
            else groundLayer = ~0; // Everything fallback
        }
    }

    void OnEnable()
    {
        InputEvents.OnMove += HandleMove;
        InputEvents.OnJump += HandleJump;
    }

    void OnDisable()
    {
        InputEvents.OnMove -= HandleMove;
        InputEvents.OnJump -= HandleJump;
    }

    void HandleMove(float v)
    {
        moveInput = v;
    }

    void HandleJump()
    {
        jumpRequested = true;
    }

    void FixedUpdate()
    {
        // Mueve usando la propiedad correcta `velocity` de Rigidbody2D
        Vector2 vel = rb.linearVelocity;
        vel.x = moveInput * moveSpeed;
        rb.linearVelocity = vel;

        // Comprueba si está en suelo cada FixedUpdate
        bool groundedNow = IsGrounded();
        if (groundedNow) canJump = true;

        if (jumpRequested)
        {
            if (groundedNow && canJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
            jumpRequested = false;
        }

        // Limita la velocidad vertical hacia arriba para evitar "volar" por colisiones
        Vector2 v2 = rb.linearVelocity;
        if (v2.y > maxUpwardSpeed) v2.y = maxUpwardSpeed;
        rb.linearVelocity = v2;
    }

    bool IsGrounded()
    {
        if (col == null) return false;
        Bounds b = col.bounds;
        // posición justo debajo del collider
        Vector2 circlePos = new Vector2(b.center.x, b.min.y - 0.01f);

        // 1) OverlapCircle check
        Collider2D c = Physics2D.OverlapCircle(circlePos, groundCheckRadius, groundLayer);
        if (c != null) return true;

        // 2) Raycast fallback
        float rayDist = Mathf.Max(groundCheckRadius * 1.5f, 0.12f);
        RaycastHit2D hit = Physics2D.Raycast(circlePos, Vector2.down, rayDist, groundLayer);
        return hit.collider != null;
    }

    void OnDrawGizmosSelected()
    {
        if (col != null)
        {
            Bounds b = col.bounds;
            Gizmos.color = Color.yellow;
            Vector3 circlePos = new Vector3(b.center.x, b.min.y - 0.01f, 0f);
            Gizmos.DrawWireSphere(circlePos, groundCheckRadius);
            Gizmos.DrawLine(circlePos, circlePos + Vector3.down * Mathf.Max(groundCheckRadius * 1.5f, 0.12f));
        }
    }
    
    // Depuración de colisiones: imprime normales de contacto para ver por qué salta al chocar
    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var contact in collision.contacts)
        {
            // Debug removed: previously logged contact normals for diagnosis
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        // opcional: se puede analizar contacto continuado aquí
    }
}
