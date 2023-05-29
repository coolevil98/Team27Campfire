using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
public class SSoundManager : MonoBehaviour
{
    public SecondarySound[] sounds;
    private bool stopIntro;
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

    void Start(){
        Play("fireintro");
        Play("oceanintro");
        Play("windintro");
        Play("introchatter");
        stopIntro = true;
    }

    void Update(){
        Debug.Log(HasStopped("fireintro"));
        if(stopIntro)
        {
            if(HasStopped("fireintro"))
            {
                stopIntro = false;
                Play("fireplaceholder");
                Play("oceanplaceholder");
                Play("windplaceholder");
            }
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

    public bool HasStopped(string name)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        if(s.source.isPlaying == false){
            return true;
        } else {
            return false;
        }
    }

    public void FadeCall(string name, float fadeSpeed, float maxVolume)
    {
        StartCoroutine(Fade(name, fadeSpeed, maxVolume));
    }  

    private IEnumerator Fade(string name, float fadeSpeed, float maxVolume)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        float currentVol = s.source.volume;

        while(s.source.volume < maxVolume)
        {
            Debug.Log(s.source.volume);
            currentVol += fadeSpeed;
            s.source.volume = currentVol;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // public void VolumeMultiplier(string name, float value)
    // {
    //     SecondarySound s = Array.Find(sounds, sound => sound.name == name);
    //     if(s == null){
    //         return;
    //     }

    //     s.source.volume *= value;
    // }

}
