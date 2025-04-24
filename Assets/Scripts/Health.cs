using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;

    private float _health;

    public event Action<float> HealthChanged;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void ReduceHealth(float health)
    {
        _health = _health - health <= 0 ? 0 : _health - health;
        HealthChanged?.Invoke(_health);
    }

    public void RestoreHealth(float health)
    {
        _health = _health + health > _maxHealth ? _maxHealth : _health += health;
        HealthChanged?.Invoke(_health);
    }
}