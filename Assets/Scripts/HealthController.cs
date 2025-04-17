using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;

    private float _health;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    public event Action<float> HealthChanged;

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