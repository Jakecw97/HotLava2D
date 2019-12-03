using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{

    public AudioMixer mainMixer;



    // Update is called once per frame
    public void setBgVolume(float volume)
    {
        mainMixer.SetFloat("bgVolume", volume);
    }
    public void setFXVolume(float volume)
    {
        mainMixer.SetFloat("sfxVolume", volume);
    }



}
