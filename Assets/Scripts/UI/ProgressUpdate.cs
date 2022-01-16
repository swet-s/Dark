using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUpdate : MonoBehaviour
{
    public int maxStuff;
    public Sprite sprite;
    public bool TestMode = false;
    public bool useNewGrad = false;
    public Gradient gradient;
    Slider slider;
    ProgressBar bar;
    void Awake()
    {
        GameObject canvas = Resources.Load<GameObject>("BarCanvas");
        GameObject clone = Instantiate(canvas);
        slider = clone.GetComponentInChildren<Slider>();
        bar = clone.GetComponentInChildren<ProgressBar>();
        bar.handle.sprite = sprite;

        if (useNewGrad)
            bar.gradient = gradient;

        slider.maxValue = maxStuff;
        slider.value = 0;
    }

    public void CountUp()
    {
        slider.value += 1;
    }

    public void CountDown()
    {
        slider.value -= 1;
    }

    public void SetMax()
    {
        slider.value = maxStuff;
    }
    private void Update()
    {
        if (Input.anyKeyDown && TestMode)
        {
            CountUp();
        }
    }
}
