using System;

public class AmmoPickupEventDispatcher
{
    public event Action<int> OnAmmoPickedUp;


    public void NotifyAmmoPickedUpListeners(int amount)
    {
        OnAmmoPickedUp?.Invoke(amount);
    }
}
