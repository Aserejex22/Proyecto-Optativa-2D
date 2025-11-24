using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [Tooltip("Transform objetivo a seguir. Si está vacío se buscará al jugador automáticamente.")]
    public Transform target;

    [Tooltip("Desplazamiento relativo entre cámara y objetivo (Z normalmente -10)")]
    public Vector3 offset = new Vector3(0f, 1.5f, -10f);

    [Tooltip("Tiempo de suavizado (Smooth) para el movimiento de cámara")]
    public float smoothTime = 0.12f;

    public bool followX = true;
    public bool followY = true;

    float velX = 0f;
    float velY = 0f;

    void Start()
    {
        if (target == null)
        {
            var player = FindObjectOfType<PlayerMovementEvents>();
            if (player != null) target = player.transform;
            else
            {
                var go = GameObject.FindWithTag("Player");
                if (go != null) target = go.transform;
            }
        }

        if (target == null)
        {
            Debug.LogWarning("CameraFollow: no se encontró target. Asigna el Transform del jugador en el Inspector o agrega la tag 'Player'.");
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desired = target.position + offset;
        Vector3 current = transform.position;
        Vector3 next = current;

        if (followX)
            next.x = Mathf.SmoothDamp(current.x, desired.x, ref velX, smoothTime);

        if (followY)
            next.y = Mathf.SmoothDamp(current.y, desired.y, ref velY, smoothTime);

        // Mantener la Z del offset (normalmente -10)
        next.z = offset.z;

        transform.position = next;
    }
}
