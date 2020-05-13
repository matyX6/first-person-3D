using System;

public class MenuDialogService
{
    public static void MainMenuDialog()
    {
        Action actionConfirm = null;
        actionConfirm = () => SceneManagerService.LoadPlayScene();

        MenuDialogContainer.Instance.ShowDialog(
            "Title",
            "Play",
            "Quit",
            actionConfirm);
    }
}
