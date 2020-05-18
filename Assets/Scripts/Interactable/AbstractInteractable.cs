using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    protected const string Untagged = "Untagged";


    [SerializeField] private string _tooltipText = "Interact with";


    public string  Tooltip { get { return _tooltipText + " " + gameObject.name; } }


    public abstract void Interact();
}
