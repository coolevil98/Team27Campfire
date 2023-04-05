using UnityEngine.Audio;
using System;
using UnityEngine;

public class SSoundManager : MonoBehaviour
{
    public SecondarySound[] sounds;
    void Awake()
    {
        foreach (SecondarySound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
        }
    }

    public void Play(string name)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            return;
        }
        s.source.Play();
    }
}
