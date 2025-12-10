using UnityEngine;

[RequireComponent(typeof(Transform))]
public class BlockController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 0.2f;
    // offsets relativos desde la posición inicial hacia la izquierda y derecha
    public float leftOffset = -2f;
    public float rightOffset = 2f;

    [HideInInspector]
    public Vector3 startPosition;

    // instancias de estados reutilizables
    [HideInInspector]
    public readonly IBlockState moveRightState = new MoveRightState();
    [HideInInspector]
    public readonly IBlockState moveLeftState = new MoveLeftState();

    IBlockState currentState;

    void Awake()
    {
        startPosition = transform.position;

        // si los offsets son iguales u 0, no nos movemos
        if (Mathf.Approximately(leftOffset, rightOffset))
        {
            currentState = null;
            return;
        }

        // iniciar moviéndose a la derecha por defecto
        currentState = moveRightState;
        currentState.Enter(this);
    }

    void Update()
    {
        currentState?.Tick(this);
    }

    public void SetState(IBlockState next)
    {
        if (next == currentState) return;
        currentState?.Exit(this);
        currentState = next;
        currentState?.Enter(this);
    }

    // utilidad para depurar en la escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 pos = Application.isPlaying ? startPosition : transform.position;
        Gizmos.DrawSphere(pos + Vector3.right * leftOffset, 0.1f);
        Gizmos.DrawSphere(pos + Vector3.right * rightOffset, 0.1f);
        Gizmos.DrawLine(pos + Vector3.right * leftOffset, pos + Vector3.right * rightOffset);
    }
}
