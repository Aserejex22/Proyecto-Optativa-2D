using UnityEngine;
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine.InputSystem;
#endif

public class InputReader : MonoBehaviour
{
    void Update()
    {
        float h = 0f;

#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
        if (Gamepad.current != null)
        {
            h = Gamepad.current.leftStick.x.ReadValue();
        }
        else if (Keyboard.current != null)
        {
            h = (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) ? -1f : 0f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) h = 1f;
        }

        bool dbgJump = (Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame);
        if (dbgJump) InputEvents.RaiseJump();
#else
    h = Input.GetAxisRaw("Horizontal");
    if (Input.GetKeyDown(KeyCode.W))
        InputEvents.RaiseJump();
#endif

        InputEvents.RaiseMove(Mathf.Clamp(h, -1f, 1f));
    }
}