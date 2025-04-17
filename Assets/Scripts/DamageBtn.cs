using UnityEngine;
using UnityEngine.UI;

public class DamageBtn : MonoBehaviour
{
    [SerializeField] private Button _damageBtn;
    [SerializeField] private HealthController _healthController;

    private float _damage = 10f;

    private void OnEnable()
    {
        _damageBtn.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _damageBtn.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _healthController.ReduceHealth(_damage);
    }
}
