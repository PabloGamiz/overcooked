using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StatusBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill; 


    public void SetMax(int max)
    {
        slider.maxValue = max;
        slider.value = 0;

        fill.color = gradient.Evaluate(0f); 
    }

    public void SetStatus(int status)
    {
        slider.value = status;

        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }
}
