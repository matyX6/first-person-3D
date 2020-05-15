using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private const string FireAxesName = "Fire1";


    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _fireRate = 15f;
    [SerializeField] private Camera _fpsCamera = null;
    [SerializeField] private ParticleSystem _muzzleFlash = null;
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
            HitImpactEffect(hit);

            IDamageable target = hit.transform.GetComponent<IDamageable>();

            if (target != null)
            {
                target.TakeDamage(_damage);
            }
        }
    }

    private void HitImpactEffect(RaycastHit hit)
    {
        List<GameObject> impactEffects = PoolManager.Instance.ObjectList;
        foreach (GameObject ie in impactEffects)
        {
            if (ie.activeInHierarchy == false)
            {
                ie.SetActive(true);
                ie.transform.position = hit.point;
                break;
            }
            else if (impactEffects.IndexOf(ie) == impactEffects.Count - 1)
            {
                GameObject newImpactEffect = Instantiate(PoolManager.Instance.ObjectToPool);
                newImpactEffect.transform.parent = PoolManager.Instance.transform;
                newImpactEffect.SetActive(false);
                impactEffects.Add(newImpactEffect);
                break;
            }
        }
    }
}
