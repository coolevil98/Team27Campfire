using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
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
            s.source.loop = s.loop;
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

    // public void FadeInCall(string name, float fadeSpeed, float maxVolume)
    // {
    //     StartCoroutine(FadeIn(name, fadeSpeed, maxVolume));
    // }  

    // private IEnumerator FadeIn(string name, float fadeSpeed, float maxVolume)
    // {
    //     SecondarySound s = Array.Find(sounds, sound => sound.name == name);
    //     float currentVol = s.source.volume;

    //     while(s.source.volume < maxVolume)
    //     {
    //         Debug.Log(s.source.volume);
    //         currentVol += fadeSpeed;
    //         s.source.volume = currentVol;
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }

    public void VolumeMultiplier(string name, float value)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            return;
        }

        s.source.volume *= value;
    }

}
