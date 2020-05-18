using System;

public class GamePauseEventDispatcher
{
    public event Action OnGamePaused;
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

    public void NotifyGamePausedListeners()
    {
        OnGamePaused?.Invoke();
    }

    public void NotifyGameResumedListeners()
    {
        OnGameResumed?.Invoke();
    }
}
