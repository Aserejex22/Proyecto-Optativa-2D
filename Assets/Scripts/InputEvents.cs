using System;

// Eventos estáticos para entrada de jugador (sin referencias Inspector).
// Suscríbete a `OnMove` y `OnJump` desde cualquier script.
public static class InputEvents
{
    // Movimiento horizontal: valor entre -1 y 1
    public static event Action<float> OnMove;
    // Evento de salto (pulsación)
    public static event Action OnJump;

    public static void RaiseMove(float value)
    {
        OnMove?.Invoke(value);
    }

    public static void RaiseJump()
    {
        OnJump?.Invoke();
    }
}
