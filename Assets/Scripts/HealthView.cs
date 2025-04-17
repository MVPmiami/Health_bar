using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private Image _sliderFillImage;

    private float _maxHealthValue = 100f;
    private float _healthScale = 100f;
    private string _slash = "/";
    private float _targetHealth;
    private float smoothSpeed = 0.2f;

    private void Start()
    {
        UpdateHealthText(_healthController.Health);
    }

    private void Update()
    {
        if (_smoothHealthSlider != null)
        {
            _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _targetHealth, smoothSpeed * Time.deltaTime);
            _sliderFillImage.enabled = _smoothHealthSlider.value != 0;
        }
    }

    private void OnEnable()
    {
        _healthController.HealthChanged += UpdateHealthText;
    }

    private void OnDisable()
    {
        _healthController.HealthChanged -= UpdateHealthText;
    }

    private void UpdateHealthText(float currentHealth)
    {
        if (_healthText != null)
        {
            _healthText.text = currentHealth != 0 ? currentHealth.ToString() + _slash + _maxHealthValue : "Dead";
        }
        if (_healthSlider != null)
        {
            _healthSlider.value = currentHealth / _healthScale;
            _sliderFillImage.enabled = _healthSlider.value != 0;
        }
        if (_smoothHealthSlider != null)
        {
            _targetHealth = currentHealth / _healthScale;
            _sliderFillImage.enabled = _smoothHealthSlider.value != 0;
        }
    }
}
