using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCreater : MonoBehaviour
{
    public AudioManager manager;

    public void PlayCoin()
    {
        manager.Play("CoinMetal");
    }

    public void PlayEnlighten()
    {
        manager.Play("Enlighten");
    }
    public void PlayShot()
    {
        manager.Play("Shot");
    }
    public void PlayJump()
    {
        manager.Play("Jump");
    }
    public void PlayPain()
    {
        manager.Play("Pain");
    }
    public void PlayReload()
    {
        manager.Play("Reload");
    }
    public void PlayClick()
    {
        manager.Play("Click");
    }
    public void PlayAhh()
    {
        manager.Play("Ahh");
    }
    public void PlayEquip()
    {
        manager.Play("Equip");
    }
    public void PlayFadeIn()
    {
        manager.Play("FadeIn");
    }
    public void PlayFadeOut()
    {
        manager.Play("FadeOut");
    }
    public void PlayTheme2()
    {
        manager.PauseTheme2(true);
        manager.Play("Theme2");
        manager.PauseTheme();
    }
    public void ResumeTheme()
    {
        manager.PauseTheme(true);
        manager.Play("Theme");
        manager.PauseTheme2();
    }

    public void PauseTheme(bool rev = false)
    {
        manager.PauseTheme(rev);
    }

    public void PauseTheme2()
    {
        manager.PauseTheme2();
    }
    public void ResumeTheme2()
    {
        manager.PauseTheme2(true);
    }
}
