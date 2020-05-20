using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    private const string HealthLossTriggerName = "health-loss";


    [Inject] private readonly GamePauseEventDispatcher _gamePauseEventDispatcher = null;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private RectTransform _healthBar = null;
    [SerializeField] private Animator _healthLoss = null;
    private float _currentHealth = 100f;
    private float _defaultHealthBarScaleX = 1f;
    private bool _healthChangeEnabled = true;


    public void ChangeHealth(float changeAmount)
    {
        if (!_healthChangeEnabled)
            return;

        if (changeAmount < 0)
            _healthLoss.SetTrigger(HealthLossTriggerName);

        _currentHealth += changeAmount;

        if (_currentHealth <= 0f)
            Die();
        else if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;

        UpdateHealthBar();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _defaultHealthBarScaleX = _healthBar.localScale.x;
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = _currentHealth / _maxHealth;

        _healthBar.localScale = new Vector2(
            _defaultHealthBarScaleX * healthPercentage, 
            _healthBar.localScale.y);
    }

    private void Die()
    {
        _healthChangeEnabled = false;
        _gamePauseEventDispatcher.NotifyPlayerDeadListeners();
        MenuDialogService.ShowDefeatScreen();
    }
}
