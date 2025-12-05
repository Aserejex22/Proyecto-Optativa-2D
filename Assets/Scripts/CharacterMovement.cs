using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectOfType<InputReader>() == null)
        {
            var go = new GameObject("InputSystem");
            go.AddComponent<InputReader>();
        }

        if (GetComponent<PlayerMovementEvents>() == null)
        {
            gameObject.AddComponent<PlayerMovementEvents>();
        }

        if (GetComponent<Rigidbody2D>() == null)
        {
            var rb = gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            rb.freezeRotation = true;
        }

        var box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            Vector2 size = box.size;
            Vector2 offset = box.offset;
            Destroy(box);
            var cap = gameObject.AddComponent<CapsuleCollider2D>();
            cap.size = size;
            cap.offset = offset;
            cap.direction = CapsuleDirection2D.Vertical;
        }
        else if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<CapsuleCollider2D>();
        }
    }
}
