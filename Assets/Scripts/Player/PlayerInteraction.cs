using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private const string InteractAxesName = "Interact";


    [SerializeField] private float _range = 5f;
    [SerializeField] private Camera _fpsCamera = null;
    private LayerMask _layerToIgnore;


    private void Start()
    {
        _layerToIgnore = LayerMask.GetMask("Trigger");
    }

    private void Update()
    {
        LookForInteraction();
    }

    private void LookForInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range, ~_layerToIgnore))
        {
            AbstractInteractable abstractInteractable = hit.transform.GetComponent<AbstractInteractable>();
            if (abstractInteractable != null)
            {
                TooltipTextContainer.Instance.ShowTooltip(abstractInteractable.Tooltip);
                if (Input.GetButtonDown(InteractAxesName))
                {
                    abstractInteractable.Interact();
                }
                return;
            }
        }
        TooltipTextContainer.Instance.HideTooltip();
    }
}
