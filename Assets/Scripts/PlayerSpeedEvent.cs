using UnityEngine;

public class PlayerSpeedEvent : MonoBehaviour
{
    public float boostedSpeed = 6f;
    public float duration = 3f;     // cuánto tiempo dura el boost
    public bool oneShot = true;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneShot && activated) return;

        PlayerMove move = other.GetComponent<PlayerMove>();

        if (move != null)
        {
            activated = true;
            StartCoroutine(ApplySpeedBoost(move));
        }
    }

    private System.Collections.IEnumerator ApplySpeedBoost(PlayerMove move)
    {
        float originalSpeed = move.moveSpeed;

        // subir velocidad
        move.moveSpeed = boostedSpeed;

        // esperar X segundos
        yield return new WaitForSeconds(duration);

        // regresar velocidad
        move.moveSpeed = originalSpeed;
    }
}
