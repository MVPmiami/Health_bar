using UnityEngine;
using UnityEngine.UI;

public class Healther : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _health;

    private float _healValue = 20f;

    private void OnEnable()
    {
        _button.onClick.AddListener(RestoreHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RestoreHealth);
    }

    private void RestoreHealth()
    {
        _health.RestoreHealth(_healValue);
    }
}
