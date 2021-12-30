using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name, bool loop)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (loop)
        {
            if (!s.source.isPlaying) s.source.Play();
        }

        else if (!loop)
        {
            s.source.Play();
        }
    }
}
