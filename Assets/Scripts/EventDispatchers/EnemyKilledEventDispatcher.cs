using System;

public class EnemyKilledEventDispatcher
{
    public event Action OnEnemyKilled;

    public void NotifyEnemyKilledListeners()
    {
        OnEnemyKilled?.Invoke();
    }
}
