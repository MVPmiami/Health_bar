using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderHealthView : HealthView
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private Image _sliderFillImage;

    private float _healthScale = 100f;
    private float _smoothSpeed = 0.2f;
    private Coroutine _coroutine;

    private void SetSliderValue(Slider slider, float currentHealth)
    {
        slider.value = currentHealth / _healthScale;
        _sliderFillImage.enabled = slider.value != 0;
    }

    private IEnumerator SetSmoothSliderValue(Slider slider, float currentHealth, float smoothSpeed)
    {
        float targetHealth = currentHealth / _healthScale;

        if (slider.value == targetHealth) yield break;

        while (slider.value != targetHealth)
        {
            slider.value = Mathf.MoveTowards(slider.value, targetHealth, smoothSpeed * Time.deltaTime);
            _sliderFillImage.enabled = slider.value != 0;

            yield return null;
        }
    }

    protected override void UpdateHealthDisplay(float currentHealth)
    {
        if (_healthSlider != null)
            SetSliderValue(_healthSlider, currentHealth);

        if (_smoothHealthSlider != null)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SetSmoothSliderValue(_smoothHealthSlider, currentHealth, _smoothSpeed));
        }
    }
}
