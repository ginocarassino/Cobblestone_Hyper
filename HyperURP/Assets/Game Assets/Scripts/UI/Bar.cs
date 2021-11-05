using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMinSpeed(int speed)
    {
        slider.maxValue = speed;
        slider.value = speed;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetSpeed(int speed)
    {
        slider.value = speed;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
