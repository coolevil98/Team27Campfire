using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
//Each sound effect will have a name, AudioClip, volume, pitch, loop option and audio source, and these will be stacked into an Array for SSoundManager to use.
public class SecondarySound
{
    public string name;

    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
