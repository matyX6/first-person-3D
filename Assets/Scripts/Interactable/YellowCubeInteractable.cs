using UnityEngine;
using Zenject;

public class YellowCubeInteractable : AbstractInteractable
{
    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;


    public override void Interact()
    {
        Debug.Log("Interact with yellow cube.");
        gameObject.tag = Untagged;
        _objectPickupEventDispatcher.NotifyYellowCubePickedUpListeners();
        Destroy(gameObject);
    }
}
