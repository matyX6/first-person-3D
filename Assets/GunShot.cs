using UnityEngine;

public class GunShot : MonoBehaviour
{
    private const string FireAxesName = "Fire1";


    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _fireRate = 15f;
    [SerializeField] private Camera _fpsCamera = null;
    [SerializeField] private ParticleSystem _muzzleFlash = null;
    [SerializeField] private GameObject _impactEffect = null;
    private float _nextTimeToFire = 0f;


    private void Update()
    {
        HandleGunShotInput();
    }

    private void HandleGunShotInput()
    {
        if (Input.GetButton(FireAxesName) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + (1f / _fireRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        _muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
        }

        GameObject impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactEffect, 2f);
    }
}
