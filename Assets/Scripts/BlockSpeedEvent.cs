using UnityEngine;

public class BlockSpeedEvent : MonoBehaviour
{
    public BlockController targetBlock;
    public float newSpeed = 1f;
    public bool oneShot = true;

    bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (oneShot && activated) return;
        activated = true;

        if (targetBlock != null)
        {
            targetBlock.speed = newSpeed;

            var sr = targetBlock.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = Color.red;
        }

        Debug.Log("Evento activado: Bloque turbo");
    }
}
