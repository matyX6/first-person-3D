using UnityEngine;

public class PlaySceneUiController : MonoBehaviour
{
    private void Update()
    {
        CheckForInput();
    }

    private static void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuDialogService.TogglePauseMenuDialog();
    }
}
