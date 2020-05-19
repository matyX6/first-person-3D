using System;

public class GamePauseEventDispatcher
{
    public event Action<bool> OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnPlayerDeath;
    public event Action OnPlayerVictory;


    public void NotifyVictoryListeners()
    {
        OnPlayerVictory?.Invoke();
    }

    public void NotifyPlayerDeadListeners()
    {
        OnPlayerDeath?.Invoke();
    }

    public void NotifyGamePausedListeners(bool enableUi)
    {
        OnGamePaused?.Invoke(enableUi);
    }

    public void NotifyGameResumedListeners()
    {
        OnGameResumed?.Invoke();
    }
}
