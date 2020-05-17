using UnityEngine;
using Zenject;

public class AmmoInteractable : AbstractInteractable
{
    [Inject] private readonly AmmoPickupEventDispatcher _ammoPickupEventDispatcher = null;
    [SerializeField] private int _ammoAmount = 32;


    public override void Interact()
    {
        Debug.Log(_ammoAmount + " ammo picked up.");
        _ammoPickupEventDispatcher.NotifyAmmoPickedUpListeners(_ammoAmount);
        Destroy(gameObject);
    }
}
