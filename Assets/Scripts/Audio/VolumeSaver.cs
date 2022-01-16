using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaver : MonoBehaviour
{
    public Slider bgm;
    public Slider sound;

    private void Start()
    {
        bgm.value = PlayerPrefs.GetFloat("bgm", -2f);
        sound.value = PlayerPrefs.GetFloat("sound", -2f);
    }
}
