using UnityEngine;
using Zenject;

public class GreenCubeInteractable : AbstractInteractable
{
    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;
    [SerializeField] private AbstractInventoryItem _inventoryItem = null;


    public override void Interact()
    {
        Debug.Log("Interact with green cube.");
        InventoryContainer.Instance.AddItemToInventory(_inventoryItem);
        gameObject.tag = Untagged;
        _objectPickupEventDispatcher.NotifyGreenCubePickedUpListeners();
        Destroy(gameObject);
    }
}
