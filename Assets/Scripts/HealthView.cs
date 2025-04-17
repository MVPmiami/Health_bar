using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public class HealthView : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private Image _sliderFillImage;

    private const string FullHealthColour = "38C842";
    private const string MediumHealthColour = "D9E02E";
    private const string LowHealthColour = "DE1F2F";

    private float _maxHealthValue = 100f;
    private float _healthScale = 100f;
    private string _slash = "/";
    private float _targetHealth;
    private float smoothSpeed = 0.2f;
    private float _lowHealthBorder = 0.3f;
    private float _mediumHealthBorder = 0.7f;

    private void Start()
    {
        UpdateHealthText(_healthController.Health);
    }

    private void Update()
    {
        if (_smoothHealthSlider != null)
        {
            SetSliderValue(_smoothHealthSlider, _targetHealth, smoothSpeed);
            ChangeSliderColour(_smoothHealthSlider);
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
            SetSliderValue(_healthSlider, currentHealth);
            ChangeSliderColour(_healthSlider);
        }
        if (_smoothHealthSlider != null)
        {
            _targetHealth = currentHealth / _healthScale;
        }
    }

    private void ChangeSliderColour(Slider slider)
    {
        switch (slider.value)
        {
            case float value when value <= _lowHealthBorder:
                ChangeColour(slider, LowHealthColour);
                break;

            case float value when value >= _mediumHealthBorder:
                ChangeColour(slider, FullHealthColour);
                break;

            default:
                ChangeColour(slider, MediumHealthColour);
                break;
        }
    }

    private void ChangeColour(Slider slider,string hexColour)
    {
        Color color;

        if (ColorUtility.TryParseHtmlString("#" + hexColour, out color))
            slider.fillRect.GetComponent<Image>().color = color;
    }

    private void SetSliderValue(Slider slider, float targetHealth)
    {
        slider.value = targetHealth / _healthScale;
        _sliderFillImage.enabled = slider.value != 0;
    }
    private void SetSliderValue(Slider slider, float targetHealth,float smoothSpeed)
    {
        slider.value = Mathf.MoveTowards(slider.value, targetHealth, smoothSpeed * Time.deltaTime);
        _sliderFillImage.enabled = slider.value != 0;
    }
}
