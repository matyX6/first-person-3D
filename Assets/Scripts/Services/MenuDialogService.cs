using System;

public class MenuDialogService
{
    public static void HideDialog()
    {
        MenuDialogContainer.Instance.gameObject.SetActive(false);
    }

    public static void ShowMainMenuDialog()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Open Your Eyes",
            "Play",
            "Quit",
            actionConfirm);
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

    private static void ShowVictoryScreen()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Victory",
            "Play Again",
            "Quit",
            actionConfirm);
    }

    private static void ShowDefeatScreen()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Defeat",
            "Play Again",
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
}
