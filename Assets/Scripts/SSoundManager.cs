﻿using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
public class SSoundManager : MonoBehaviour
{
    public SecondarySound[] sounds; //imports array of sound effects
    private bool playIntro;
    public DimFire fireTimer;
    void Awake()
    {
        foreach (SecondarySound s in sounds)
        {
            //loops through sound effect array, gives them each an audio source and assigns all audio parameters (i.e. volume, pitch, etc) set in the inspector to that audio source
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
        Play("wind");
        Play("introchatter");
        Play("introchatter2");
        Play("randomtalk1");
        Play("randomtalk2");
        Play("randomtalk4");
        Play("randomtalk8");
        Play("randomtalk9");
        playIntro = true;
    }

    void Update(){
        if(playIntro)
        {
            //there are separate versions of the main sound tracks played for the first 15 seconds as they have a fade-in effect, and they aren't supposed to be looped. 
            //Once those are finished, play the main version of those tracks, which are the ones that loop.
            //Cicadas are started here so they don't start immediately
            if(HasStopped("fireintro"))
            {
                playIntro = false;
                Play("fire");
                Play("ocean");
                Play("cicadas");
            }
        }

        //System for determining what sound effect plays where, based on how long the fire has been on. A window of 0.5s is given so that the sound actually starts during that time
        //and doesn't try to play itself forever
        if(fireTimer.getTimer >= 5.0f && fireTimer.getTimer <= 5.5f){
            Play("Narration1");
        }

        if(fireTimer.getTimer >= 10.0f && fireTimer.getTimer <= 10.5f){
            Play("bottledrink");
        }

        if(fireTimer.getTimer >= 12.0f && fireTimer.getTimer <= 12.5f){
            Play("chairshuffle1");
        }

        if(fireTimer.getTimer >= 17.0f && fireTimer.getTimer <= 17.5f){
            Play("Narration2");
        }

        if(fireTimer.getTimer >= 30.0f && fireTimer.getTimer <= 30.5f){
            Play("crickets");
            Play("randomtalk10");

        }

        if(fireTimer.getTimer >= 35.0f && fireTimer.getTimer <= 35.5f){
            Play("randomtalk3");
        }

        if(fireTimer.getTimer >= 40.0f && fireTimer.getTimer <= 40.5f){
            Play("randomtalk5");
        }

        if(fireTimer.getTimer >= 55.0f && fireTimer.getTimer <= 55.5f){
            Play("murmur");
            Play("randomtalk11");
        }

        if(fireTimer.getTimer >= 75.0f && fireTimer.getTimer <= 75.5f){
            Play("chairshuffle2");
        }

        if(fireTimer.getTimer >= 90.0f && fireTimer.getTimer <= 90.5f){
            Play("chairshuffle3");
            Play("randomtalk6");

        }

        if(fireTimer.getTimer >= 110.0f && fireTimer.getTimer <= 110.5f){
            Play("randomtalk7");
        }

        if(fireTimer.getTimer >= 180.0f && fireTimer.getTimer <= 180.5f){
            Play("murmur2");
        }

        if(fireTimer.getTimer >= 200.0f && fireTimer.getTimer <= 200.5f){
            Play("bottledrink2");
        }

        if(fireTimer.getTimer >= 222.0f && fireTimer.getTimer <= 222.5f){
            Play("baglook");
        }

        if(fireTimer.getTimer >= 235.0f && fireTimer.getTimer <= 235.5f){
            Play("cupfiddle");
        }

        if(fireTimer.getTimer >= 250.0f && fireTimer.getTimer <= 250.5f){
            Play("murmur3");
        }

        if(fireTimer.getTimer >= 285.0f && fireTimer.getTimer <= 285.5f){
            Play("murmur4");
        }

        if(fireTimer.getTimer >= 320.0f && fireTimer.getTimer <= 320.5f){
            Play("Narration3");
        }

        if(fireTimer.getTimer >= 350.0f && fireTimer.getTimer <= 350.5f){
            Play("tentzip");
        }

        if(fireTimer.getTimer >= 380.0f && fireTimer.getTimer <= 380.5f){
            Play("crickets");
            Play("sleepingbagroll");
        }

        if(fireTimer.getTimer >= 410.0f && fireTimer.getTimer <= 410.5f){
            Play("sigh 1");
        }

        if(fireTimer.getTimer >= 415.0f && fireTimer.getTimer <= 415.5f){
            Play("Narration4");
        }

        if(fireTimer.getTimer >= 440.0f && fireTimer.getTimer <= 440.5f){
            Play("sleepingbagroll2");
        }

        if(fireTimer.getTimer >= 450.0f && fireTimer.getTimer <= 450.5f){
            Play("murmur5");
        }

        if(fireTimer.getTimer >= 470.0f && fireTimer.getTimer <= 470.5f){
            Play("sleepingbagroll3");
        }

        if(fireTimer.getTimer >= 485.0f && fireTimer.getTimer <= 485.5f){
            Play("Narration5");
        }

        if(fireTimer.getTimer >= 510.0f && fireTimer.getTimer <= 510.5f){
            Play("tentzip2");
        }

        if(fireTimer.getTimer >= 520.0f && fireTimer.getTimer <= 520.5f){
            Play("bottledrink3");
        }

        if(fireTimer.getTimer >= 527.0f && fireTimer.getTimer <= 527.5f){
            Play("sigh2");
        }

        if(fireTimer.getTimer >= 540.0f && fireTimer.getTimer <= 540.5f){
            Play("cupfiddle3");
        }

        if(fireTimer.getTimer >= 550.0f && fireTimer.getTimer <= 550.5f){
            Play("sleepingbagroll4");
        }

        if(fireTimer.getTimer >= 555.0f && fireTimer.getTimer <= 550.5f){
            Play("sigh3");
        }

        if(fireTimer.getTimer >= 560.0f && fireTimer.getTimer <= 560.5f){
            Play("sleepingbagroll5");
        }

        if(fireTimer.getTimer >= 575.0f && fireTimer.getTimer <= 575.5f){
            Play("Narration6");
        }

        if(fireTimer.getTimer >= 600.0f && fireTimer.getTimer <= 600.5f){
            Play("tentzip3");
            Play("crickets");
        }
    }

    //function for playing a given audio clip
    public void Play(string name)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            return;
        }
        s.source.Play();
    }

    //function that checks if an audio clip has stopped playing (only used for checking if the intro parts of main tracks have stopped)
    public bool HasStopped(string name)
    {
        SecondarySound s = Array.Find(sounds, sound => sound.name == name);
        if(s.source.isPlaying == false){
            return true;
        } else {
            return false;
        }
    }

    //function that allows the fade function to be accessed elsewhere in the code
    public void FadeCall(string name, float fadeSpeed, float maxVolume)
    {
        StartCoroutine(Fade(name, fadeSpeed, maxVolume));
    }  

    //function that mimics a fading effect. A given audio clip is slowly increased in volume (fadeSpeed) until a given maxVolume is reached. This can also fade out (I think) if
    //fadeSpeed is negative
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

}
