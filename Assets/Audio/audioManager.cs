using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{
    public sound[] sounds;

    void Awake()
    {
       foreach(sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            
        }
    }


    public void Play(string name)
    {
        Array.Find(sounds, sound => sound.name == name);
    }
} 


