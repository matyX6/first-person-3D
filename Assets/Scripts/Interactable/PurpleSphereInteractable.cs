using UnityEngine;
using Zenject;

public class PurpleSphereInteractable : AbstractInteractable
{
    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;


    public override void Interact()
    {
        Debug.Log("Interact with purple sphere.");
        InventoryContainer.Instance.AddItemToInventory(InventoryItem);
        _objectPickupEventDispatcher.NotifyPurpleSpherePickedUpListeners();
        Destroy(gameObject);
    }
}
