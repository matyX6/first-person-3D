using System;

public class ObjectPickupEventDispatcher
{
    public event Action<int> OnAmmoPickedUp;
    public event Action OnGreenCubePickedUp;
    public event Action OnYellowCubePickedUp;
    public event Action OnPurpleSpherePickedUp;


    public void NotifyAmmoPickedUpListeners(int amount)
    {
        OnAmmoPickedUp?.Invoke(amount);
    }

    public void NotifyGreenCubePickedUpListeners()
    {
        OnGreenCubePickedUp?.Invoke();
    }

    public void NotifyYellowCubePickedUpListeners()
    {
        OnYellowCubePickedUp?.Invoke();
    }

    public void NotifyPurpleSpherePickedUpListeners()
    {
        OnPurpleSpherePickedUp?.Invoke();
    }
}
