using TMPro;
using UnityEngine;

public class TextHealthView : HealthView
{
    [SerializeField] private TextMeshProUGUI _healthText;

    private float _maxHealthValue = 100f;
    private string _slash = "/";

    private void Start()
    {
        UpdateHealthDisplay(_maxHealthValue);
    }

    private void UpdateHealthText(float currentHealth)
    {
        if (_healthText != null)
            _healthText.text = currentHealth != 0 ? currentHealth.ToString() + _slash + _maxHealthValue : "Dead";
    }

    protected override void UpdateHealthDisplay(float currentHealth)
    {
        UpdateHealthText(currentHealth);
    }
}
