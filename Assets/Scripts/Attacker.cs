using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _health;

    private float _damage = 10f;

    private void OnEnable()
    {
        _button.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _health.ReduceHealth(_damage);
    }
}
