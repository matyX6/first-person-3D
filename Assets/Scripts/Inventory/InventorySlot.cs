using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private Stack<AbstractInventoryItem> _stack = new Stack<AbstractInventoryItem>();


    public bool AddItem(AbstractInventoryItem item)
    {
        if (_stack.Count == 0)
        {
            _stack.Push(item);
            return true;
        }

        bool stackFull = _stack.Count >= item.MaxStacks;
        bool stackTypeEquals = _stack.ElementAt(0).ItemIndex == item.ItemIndex;

        if (!stackFull && stackTypeEquals)
        {
            _stack.Push(item);
            return true;
        }

        return false;
    }
}
