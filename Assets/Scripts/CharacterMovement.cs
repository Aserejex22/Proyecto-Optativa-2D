using UnityEngine;

// para que el jugador use el sistema de input por eventos.
public class CharacterMovement : MonoBehaviour
{
    void Awake()
    {
        // Asegura que exista un InputReader en la escena (crea uno si hace falta)
        if (FindObjectOfType<InputReader>() == null)
        {
            var go = new GameObject("InputSystem");
            go.AddComponent<InputReader>();
        }

        // Asegura que el PlayerMovementEvents esté presente en este GameObject
        if (GetComponent<PlayerMovementEvents>() == null)
        {
            gameObject.AddComponent<PlayerMovementEvents>();
        }

        // Asegura Rigidbody2D dinámico
        if (GetComponent<Rigidbody2D>() == null)
        {
            var rb = gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            rb.freezeRotation = true;
        }

        // Asegura algún Collider2D (BoxCollider2D por defecto) si no hay ninguno
        // Si hay un BoxCollider2D, reemplázalo por CapsuleCollider2D (mejor para personajes)
        var box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            Vector2 size = box.size;
            Vector2 offset = box.offset;
            // destruir el BoxCollider2D y añadir un CapsuleCollider2D con las mismas dimensiones aproximadas
            Destroy(box);
            var cap = gameObject.AddComponent<CapsuleCollider2D>();
            cap.size = size;
            cap.offset = offset;
            cap.direction = CapsuleDirection2D.Vertical;
        }
        else if (GetComponent<Collider2D>() == null)
        {
            // Si no hay ningún collider, añade un CapsuleCollider2D por defecto
            gameObject.AddComponent<CapsuleCollider2D>();
        }
    }
}
