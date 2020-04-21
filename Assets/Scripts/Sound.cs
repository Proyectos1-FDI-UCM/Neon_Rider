using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name; 

    public AudioClip clip; 
    public AudioMixerGroup mixer; 

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}