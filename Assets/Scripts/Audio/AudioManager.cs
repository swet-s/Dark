using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mixer1;
    public AudioMixerGroup soundEffects;
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            if (s.name == "Theme" || s.name == "Theme2")
                s.source.outputAudioMixerGroup = mixer1;
            else
                s.source.outputAudioMixerGroup = soundEffects;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    private void Start()
    {
       Play("Theme");
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PauseTheme(bool rev = false)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "Theme" && !rev)
                s.source.pitch = 0;
            else if (s.name == "Theme" && rev)
                s.source.pitch = 1;
        }
    }
    public void PauseTheme2(bool rev = false)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == "Theme2" && !rev)
                s.source.pitch = 0;
            else if (s.name == "Theme2" && rev)
                s.source.pitch = 1;
        }
    }
}
