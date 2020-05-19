using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    protected const string Untagged = "Untagged";


    [SerializeField] private string _tooltipText = "Interact with";
    [SerializeField] private AbstractInventoryItem _inventoryItem = null;


    public string  Tooltip => _tooltipText + " " + gameObject.name;
    public AbstractInventoryItem InventoryItem => _inventoryItem;


    public abstract void Interact();
}
