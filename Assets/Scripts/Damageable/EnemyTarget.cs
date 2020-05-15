using UnityEngine;

public class EnemyTarget : Target
{
    [SerializeField] private MeshRenderer _meshRenderer = null;
    [SerializeField] private Color _hitColor = Color.red;
    private Color _defaultColor = Color.white;

    protected override void Start()
    {
        base.Start();
        _defaultColor = _meshRenderer.material.color;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        ChangeEnemyColor();
    }

    private void ChangeEnemyColor()
    {
        float damagePercentage = _currentHealth / _maxHealth;
        Color lerpedColor = Color.Lerp(_hitColor, _defaultColor, damagePercentage);
        _meshRenderer.material.color = lerpedColor;
    }
}
