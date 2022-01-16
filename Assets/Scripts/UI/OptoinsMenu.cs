using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptoinsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundMixer;
    public float minThreshold;
    public void SetMusic(float volume)
    {
        if (volume < minThreshold)
            volume = -80f;
        musicMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("bgm", volume);
    }
    public void SetSound(float volume)
    {
        if (volume < minThreshold)
            volume = -80f;
        soundMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("sound", volume);
    }
    public void SetCharacter(int index)
    {
        PlayerPrefs.SetInt("PlayerIndex", index);
    }
} 