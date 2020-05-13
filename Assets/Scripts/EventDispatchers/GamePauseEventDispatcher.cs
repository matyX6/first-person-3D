using System;

public class GamePauseEventDispatcher
{
    public event Action OnGamePaused;
    public event Action OnGameResumed;

    public void NotifyGamePausedListeners()
    {
        OnGamePaused?.Invoke();
    }

    public void NotifyGameResumedListeners()
    {
        OnGameResumed?.Invoke();
    }
}
