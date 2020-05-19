using UnityEngine;

public abstract class AbstractInventoryItem : MonoBehaviour
{
    [SerializeField] private Sprite _itemIcon = null;
    [SerializeField] private int _maxStacks = 5;


    public abstract InventoryItem ItemIndex { get;}
    public int MaxStacks => _maxStacks;
    public Sprite ItemIcon => _itemIcon;
}
