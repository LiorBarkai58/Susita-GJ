using UnityEngine;
using UnityEngine.UI;

public class Overheat : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100;
    public float heatRate = 1;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    void Update()
    {
        slider.value -= heatRate * Time.deltaTime;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
