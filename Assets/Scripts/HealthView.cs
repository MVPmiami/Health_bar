using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void UpdateHealthDisplay(float currentHealth);

    protected void OnHealthChanged(float currentHealth)
    {
        UpdateHealthDisplay(_health.CurrentHealth);
    }
}
