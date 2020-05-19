using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _lifetime = 2f;


    private void Start()
    {
        Invoke("SelfDestroy", _lifetime);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
