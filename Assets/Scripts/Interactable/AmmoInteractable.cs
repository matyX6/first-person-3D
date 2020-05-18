using UnityEngine;
using Zenject;

public class AmmoInteractable : AbstractInteractable
{
    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;
    [SerializeField] private int _ammoAmount = 32;


    public override void Interact()
    {
        Debug.Log(_ammoAmount + " ammo picked up.");
        _objectPickupEventDispatcher.NotifyAmmoPickedUpListeners(_ammoAmount);
        Destroy(gameObject);
    }
}
