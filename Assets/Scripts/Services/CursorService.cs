using System;
using UnityEngine;

public class CursorService
{
    public static void HideAndLock()
    {
        SetCursorStates(false, CursorLockMode.Locked);
    }

    public static void ShowAndUnlock()
    {
        SetCursorStates(true, CursorLockMode.Confined);
    }

    private static void SetCursorStates(bool visible, CursorLockMode cursorLockMode)
    {
        Cursor.visible = visible;
        Cursor.lockState = cursorLockMode;
    }
}
