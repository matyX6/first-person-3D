using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;
    [SerializeField] private GameObject _slotsParent = null;
    private List<InventorySlot> _inventorySlotsList = new List<InventorySlot>();


    public void AddItemToInventory(AbstractInventoryItem item)
    {
        bool itemAdded = false;

        foreach (InventorySlot inventorySlot in _inventorySlotsList)
        {
            itemAdded = inventorySlot.AddItem(item);

            if (itemAdded)
            {
                Debug.Log("Item added to inventory!");
                break;
            }
        }

        if (!itemAdded)
            Debug.Log("Inventory full!");
    }

    public void Initialize()
    {
        _inventorySlotsList = _slotsParent.GetComponentsInChildren<InventorySlot>().ToList();
    }

    private void OnEnable()
    {
        _gamePauseEventDispatcher.NotifyGamePausedListeners(true);
    }

    private void OnDisable()
    {
        _gamePauseEventDispatcher.NotifyGameResumedListeners();
    }
}
