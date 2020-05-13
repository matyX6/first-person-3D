using System;

public class MenuDialogService
{
    public static void ShowMainMenuDialog()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Title",
            "Play",
            "Quit",
            actionConfirm);
    }

    public static void TogglePauseMenuDialog()
    {
        bool dialogOpened = MenuDialogContainer.Instance.gameObject.activeSelf;

        if (dialogOpened)
            HideDialog();
        else
            ShowPauseMenuDialog();
    }

    private static void ShowPauseMenuDialog()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Pause",
            "Restart",
            "Quit",
            actionConfirm);
    }

    public static void HideDialog()
    {
        MenuDialogContainer.Instance.gameObject.SetActive(false);
    }
}
