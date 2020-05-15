﻿using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _maxHealth = 100f;
    [SerializeField] private float _hitScaleMultiplier = 1.3f;
    protected float _currentHealth = 100f;
    private Vector3 _defaultScale = Vector3.one;
    private Vector3 _hitScale = Vector3.one;


    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _defaultScale = transform.localScale;
        _hitScale = _defaultScale * 1.3f;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0f)
            Die();

        AnimateDamageTaken();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void AnimateDamageTaken()
    {
        transform.DOKill(false);
        transform.localScale = _hitScale;
        transform.DOScale(_defaultScale, .2f);
    }
}
