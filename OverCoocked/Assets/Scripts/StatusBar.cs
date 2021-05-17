using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class StatusBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public bool hasFinished; 
    bool cutting;
    
    float time; 


    void Update()
    {
        if (cutting)
        {
            time += Time.deltaTime;
            SetStatus();
            if (time >= slider.maxValue) //Finish cutting
            {
                cutting = false;
                hasFinished = true; 
                gameObject.SetActive(false);
                time = 0; 
            }
        }
    }

    public bool HasFinished()
    {
        return hasFinished; 
    }

    public void Cut()
    {
        gameObject.SetActive(true);
        cutting = true;
        hasFinished = false; 
    }

    public void SetMax(int max)
    {
        slider.maxValue = max;
        slider.value = 0;
        time = 0;
        hasFinished = false; 
        fill.color = gradient.Evaluate(0f); 
    }

    void SetStatus()
    {
        slider.value = time;
        fill.color = gradient.Evaluate(slider.normalizedValue); 
    }

  
}
