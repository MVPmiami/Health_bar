using UnityEngine;
using UnityEngine.UI;

public class RestoreHealthBtn : MonoBehaviour
{
    [SerializeField] private Button _restoreBtn;
    [SerializeField] private HealthController _healthController;

    private float _healValue = 20f;

    private void OnEnable()
    {
        _restoreBtn.onClick.AddListener(RestoreHealth);
    }

    private void OnDisable()
    {
        _restoreBtn.onClick.RemoveListener(RestoreHealth);
    }

    private void RestoreHealth()
    {
        _healthController.RestoreHealth(_healValue);
    }
}
