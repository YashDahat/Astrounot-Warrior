using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void Setmax(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void  Healthbar(float health)
    {
        slider.value = health;
    }
}
