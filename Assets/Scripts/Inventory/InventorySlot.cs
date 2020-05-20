using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Stack<AbstractInventoryItem> _stack = new Stack<AbstractInventoryItem>();


    [SerializeField] private Image _slotIcon = null;
    [SerializeField] private Image _clearSlotIcon = null;
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

    public void ClearSlot()
    {
        _stack.Clear();
        DisableSlotVisuals();
    }

    private void UpdateItemSlot(AbstractInventoryItem item)
    {
        UpdateIcons(_stack.ElementAt(0));
        UpdateItemCount();
    }

    private void UpdateIcons(AbstractInventoryItem item)
    {
        _clearSlotIcon.enabled = true;
        _slotIcon.enabled = true;
        _slotIcon.sprite = item.ItemIcon;
    }

    private void UpdateItemCount()
    {
        _slotItemsNumber.enabled = true;
        _slotItemsNumber.text = _stack.Count.ToString();
    }

    private void DisableSlotVisuals()
    {
        _clearSlotIcon.enabled = false;
        _slotIcon.enabled = false;
        _slotItemsNumber.enabled = false;
    }
}
