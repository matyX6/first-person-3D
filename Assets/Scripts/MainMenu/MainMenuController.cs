using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void ShowMainMenuDialog() //triggered by animator, animation event
    {
        MenuDialogService.ShowMainMenuDialog();
    }
}
