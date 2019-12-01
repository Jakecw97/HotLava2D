using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SoundScript : MonoBehaviour
{
    public Sound[] sounds;
    public AudioClip audioClip;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        //Error Handling if the sound cannot be found
        if (s == null)
            return;


        s.source.Play();
    }

}

