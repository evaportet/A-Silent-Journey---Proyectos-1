using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioSource button;
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        button.Play();
        audioMixer.SetFloat("Volume", volume);

    }    
    
}
