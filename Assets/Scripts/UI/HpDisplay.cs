using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : MonoBehaviour
{
    public Slider slider;
    public void SetMaxVal(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetValue(float value)
    {
        slider.value = value;
    }
}
