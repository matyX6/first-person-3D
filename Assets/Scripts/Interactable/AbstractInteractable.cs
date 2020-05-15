using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    [SerializeField] private string _tooltipText = "Interact with";


    public string  Tooltip { get { return _tooltipText + " " + gameObject.name; } }


    public abstract void Interact();
}
