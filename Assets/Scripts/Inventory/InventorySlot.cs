using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Stack<AbstractInventoryItem> _stack = new Stack<AbstractInventoryItem>();


    [SerializeField] private Image _slotIcon = null;
    [SerializeField] private Text _slotItemsNumber = null;


    public bool AddItem(AbstractInventoryItem item)
    {
        if (_stack.Count == 0)
        {
            _stack.Push(item);
            UpdateItemSlot(item);
            return true;
        }

        bool stackFull = _stack.Count >= _stack.ElementAt(0).MaxStacks;
        bool stackTypeEquals = _stack.ElementAt(0).ItemIndex == item.ItemIndex;

        if (!stackFull && stackTypeEquals)
        {
            _stack.Push(item);
            UpdateItemSlot(item);
            return true;
        }

        return false;
    }

    private void UpdateItemSlot(AbstractInventoryItem item)
    {
        UpdateSlotIcon(_stack.ElementAt(0));
        UpdateItemCount();
    }

    private void UpdateSlotIcon(AbstractInventoryItem item)
    {
        _slotIcon.enabled = true;
        _slotIcon.sprite = item.ItemIcon;
    }

    private void UpdateItemCount()
    {
        _slotItemsNumber.enabled = true;
        _slotItemsNumber.text = _stack.Count.ToString();
    }
}
