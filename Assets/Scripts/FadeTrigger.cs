using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour
{
    public Animator fade;
    public bool playOnAwake = true;
    public bool wildintro = false;
    void Awake()
    {
        if (playOnAwake)
            fade.SetTrigger("Startfade");
        if (wildintro)
            fade.SetTrigger("WildIntro");
    }
    public void Fade()
    {
        fade.SetTrigger("Startfade");
    }
    public void Outro()
    {
        fade.SetTrigger("Startout");
    }
    public void Outro2()
    {
        fade.SetTrigger("Startout2");
    }
}
