using System;

public class GamePauseEventDispatcher
{
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnPlayerDeath;

    public void NotifyPlayerDeadListeners()
    {
        OnPlayerDeath?.Invoke();
    }

    public void NotifyGamePausedListeners()
    {
        OnGamePaused?.Invoke();
    }

    public void NotifyGameResumedListeners()
    {
        OnGameResumed?.Invoke();
    }
}
