using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _range = 5f;
    [SerializeField] private Camera _fpsCamera = null;


    private void Update()
    {
        LookForInteraction();
    }

    private void LookForInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
            AbstractInteractable abstractInteractable = hit.transform.GetComponent<AbstractInteractable>();
            if (abstractInteractable != null)
            {
                TooltipTextContainer.Instance.ShowTooltip(abstractInteractable.Tooltip);
                return;
            }
        }
        else
        {
            TooltipTextContainer.Instance.HideTooltip();
        }
    }
}
