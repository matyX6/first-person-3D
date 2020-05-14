using UnityEngine;

public class AbstractInteractable : MonoBehaviour
{
    [SerializeField] private string _tooltipText = "Interact with ";


    public string  Tooltip { get { return _tooltipText + gameObject.name; } }


    public void Interact()
    {
        Debug.Log("Interact!");
    }
}
