using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Gun : MonoBehaviour
{
    private const string FireAxesName = "Fire1";


    [Inject] private readonly ObjectPickupEventDispatcher _objectPickupEventDispatcher = null;
    [SerializeField] private int _maxAmmo = 100;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _fireRate = 15f;
    [SerializeField] private RectTransform _ammoBar = null;
    [SerializeField] private Text _ammoText = null;
    [SerializeField] private Camera _fpsCamera = null;
    [SerializeField] private ParticleSystem _muzzleFlash = null;
    private float _defaultAmmoBarScaleX = 1f;
    private float _nextTimeToFire = 0f;
    private int _currentAmmo = 100;
    private LayerMask _layerToIgnore;


    private void Start()
    {
        _layerToIgnore = LayerMask.GetMask("Trigger");

        _currentAmmo = _maxAmmo;
        _defaultAmmoBarScaleX = _ammoBar.localScale.x;

        _objectPickupEventDispatcher.OnAmmoPickedUp += AmmoPickup;

        UpdateAmmoBarAndText();
    }

    private void OnDestroy()
    {
        _objectPickupEventDispatcher.OnAmmoPickedUp -= AmmoPickup;
    }

    private void Update()
    {
        HandleGunShotInput();
    }

    private void HandleGunShotInput()
    {
        if (Input.GetButton(FireAxesName) && Time.time >= _nextTimeToFire && _currentAmmo > 0)
        {
            _nextTimeToFire = Time.time + (1f / _fireRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        _muzzleFlash.Play();
        _currentAmmo--;
        UpdateAmmoBarAndText();

        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out hit, _range, ~_layerToIgnore))
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

    private void UpdateAmmoBarAndText()
    {
        float ammoPercentage = (float)_currentAmmo / (float)_maxAmmo;

        _ammoBar.localScale = new Vector2(
            _defaultAmmoBarScaleX * ammoPercentage,
            _ammoBar.localScale.y);

        _ammoText.text = _currentAmmo.ToString() + "/" + _maxAmmo.ToString();
    }

    private void AmmoPickup(int amount)
    {
        _currentAmmo += amount;

        if (_currentAmmo > _maxAmmo)
            _currentAmmo = _maxAmmo;

        UpdateAmmoBarAndText();
    }
}
