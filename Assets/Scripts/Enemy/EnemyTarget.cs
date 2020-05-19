using UnityEngine;

public class EnemyTarget : Target
{
    [SerializeField] private MeshRenderer _meshRendererBody = null;
    [SerializeField] private MeshRenderer _meshRendererHead = null;
    [SerializeField] private GameObject _detahParticles = null;
    [SerializeField] private Color _hitColor = Color.red;
    private Color _defaultColor = Color.white;

    protected override void Start()
    {
        base.Start();
        _defaultColor = _meshRendererBody.material.color;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        ChangeEnemyColor();
    }

    public override void Die()
    {
        Instantiate(_detahParticles, gameObject.transform.position, Quaternion.identity);
        base.Die();
    }

    private void ChangeEnemyColor()
    {
        float damagePercentage = _currentHealth / _maxHealth;
        Color lerpedColor = Color.Lerp(_hitColor, _defaultColor, damagePercentage);
        _meshRendererBody.material.color = lerpedColor;
        _meshRendererHead.material.color = lerpedColor;
    }
}
