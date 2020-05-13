using UnityEngine;
using Zenject;

public class PlaySceneManager : MonoBehaviour
{
    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;
    [SerializeField] private PlayerMovement _playerMovement = null;
    [SerializeField] private MouseLook _mouseLook = null;

    private void Awake()
    {
        CursorService.HideAndLock();
        _gamePauseEventDispatcher.OnGamePaused += DisablePlayerMovementAndLook;
        _gamePauseEventDispatcher.OnGameResumed += EnablePlayerMovementAndLook;
    }

    private void OnDestroy()
    {
        _gamePauseEventDispatcher.OnGamePaused -= DisablePlayerMovementAndLook;
        _gamePauseEventDispatcher.OnGameResumed -= EnablePlayerMovementAndLook;
    }

    private void Update()
    {
        CheckForPauseInput();
    }

    private void CheckForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuDialogService.TogglePauseMenuDialog();
    }

    private void EnablePlayerMovementAndLook()
    {
        _playerMovement.enabled = true;
        _mouseLook.enabled = true;
        CursorService.HideAndLock();
    }

    private void DisablePlayerMovementAndLook()
    {
        _playerMovement.enabled = false;
        _mouseLook.enabled = false;
        CursorService.ShowAndUnlock();
    }
}
