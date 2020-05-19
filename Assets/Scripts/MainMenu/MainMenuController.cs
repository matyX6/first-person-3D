using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioSource _musicPlayer = null;


    private void ShowMainMenuDialog() //triggered by animator, animation event
    {
        MenuDialogService.ShowMainMenuDialog();
    }

    private void PlayMusic() //triggered by animator, animation event
    {
        _musicPlayer.Play();
    }
}
