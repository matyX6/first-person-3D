using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;


    private void OnEnable()
    {
        _gamePauseEventDispatcher.NotifyGamePausedListeners();
    }

    private void OnDisable()
    {
        _gamePauseEventDispatcher.NotifyGameResumedListeners();
    }
}
