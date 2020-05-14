using UnityEngine;

public class GunShot : MonoBehaviour
{
    private const string FireAxesName = "Fire1";


    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private Camera _fpsCamera = null;
    [SerializeField] private ParticleSystem _shotFlash = null;

    private void Update()
    {
        HandleGunShotInput();
    }

    private void HandleGunShotInput()
    {
        if (Input.GetButtonDown(FireAxesName))
        {
            _shotFlash.Play(); 

            RaycastHit hit;
            if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
