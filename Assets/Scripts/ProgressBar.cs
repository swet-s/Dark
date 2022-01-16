using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Image handle;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
