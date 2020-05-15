using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    [SerializeField] private float health = 100f;
    private Vector3 _defaultScale = Vector3.one;
    private Vector3 _hitScale = Vector3.one;


    private void Start()
    {
        _defaultScale = transform.localScale;
        _hitScale = _defaultScale * 1.3f;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0f)
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
