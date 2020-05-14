using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Disable", .5f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
