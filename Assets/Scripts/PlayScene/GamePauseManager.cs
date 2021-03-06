﻿using UnityEngine;
using Zenject;

public class GamePauseManager : MonoBehaviour
{
    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;
    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _playerUi = null;
    [SerializeField] private PlayerMovement _playerMovement = null;
    [SerializeField] private MouseLook _mouseLook = null;
    [SerializeField] private Gun _gun = null;
    private bool _inputCheckEnabled = true;


    private void Awake()
    {
        CursorService.HideAndLock();
        _gamePauseEventDispatcher.OnGamePaused += DisablePlayerComponents;
        _gamePauseEventDispatcher.OnGameResumed += EnablePlayerComponents;
        _gamePauseEventDispatcher.OnPlayerDeath += DisableInputCheck;
        _gamePauseEventDispatcher.OnPlayerVictory += DisableInputCheck;
    }

    private void OnDestroy()
    {
        _gamePauseEventDispatcher.OnGamePaused -= DisablePlayerComponents;
        _gamePauseEventDispatcher.OnGameResumed -= EnablePlayerComponents;
        _gamePauseEventDispatcher.OnPlayerDeath -= DisableInputCheck;
        _gamePauseEventDispatcher.OnPlayerVictory -= DisableInputCheck;
    }

    private void Update()
    {
        CheckForPauseInput();
        CheckForInventoryInput();
    }

    private void CheckForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _inputCheckEnabled)
            MenuDialogService.TogglePauseMenuDialog();
    }

    private void CheckForInventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && _inputCheckEnabled)
        {
            bool menuActive = MenuDialogContainer.Instance.gameObject.activeSelf;
            bool inventoryActive = InventoryContainer.Instance.gameObject.activeSelf;

            InventoryContainer.Instance.gameObject.SetActive(!menuActive && !inventoryActive);
        }
    }

    private void EnablePlayerComponents()
    {
        if (_player != null)
        {
            _playerMovement.enabled = true;
            _mouseLook.enabled = true;
            _gun.enabled = true;
            _playerUi.SetActive(true);
        }

        CursorService.HideAndLock();
    }

    private void DisablePlayerComponents(bool enableUi)
    {
        if (_player != null)
        {
            _playerMovement.enabled = false;
            _mouseLook.enabled = false;
            _gun.enabled = false;
            _playerUi.SetActive(enableUi);
        }

        CursorService.ShowAndUnlock();
    }

    private void DisableInputCheck()
    {
        _inputCheckEnabled = false;
    }
}
