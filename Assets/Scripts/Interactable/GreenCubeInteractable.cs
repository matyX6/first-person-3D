﻿using UnityEngine;
using Zenject;

public class GreenCubeInteractable : AbstractInteractable
{
    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;


    public override void Interact()
    {
        Debug.Log("Interact with green cube.");
        _objectPickupEventDispatcher.NotifyGreenCubePickedUpListeners();
        Destroy(gameObject);
    }
}
