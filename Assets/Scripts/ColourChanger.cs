using UnityEngine;
using UnityEngine.UI;

public class ColourChanger : HealthView
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;

    private const string FullHealthColour = "38C842";
    private const string MediumHealthColour = "D9E02E";
    private const string LowHealthColour = "DE1F2F";

    private float _lowHealthBorder = 0.3f;
    private float _mediumHealthBorder = 0.7f;
    private float _healthScale = 100f;

    private void ChangeSliderColour(Slider slider, float targetHealth)
    {
        switch (targetHealth)
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

    private void ChangeColour(Slider slider, string hexColour)
    {
        Color color;

        if (ColorUtility.TryParseHtmlString("#" + hexColour, out color))
            slider.fillRect.GetComponent<Image>().color = color;
    }

    protected override void UpdateHealthDisplay(float currentHealth)
    {
        float targetHealth = currentHealth / _healthScale;

        if(_healthSlider != null)
            ChangeSliderColour(_healthSlider, targetHealth);
        else if(_smoothHealthSlider != null)
            ChangeSliderColour(_smoothHealthSlider, targetHealth);
    }
}
