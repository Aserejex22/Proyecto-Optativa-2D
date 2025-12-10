using System;

public static class InputEvents
{

    public static event Action<float> OnMove;
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
