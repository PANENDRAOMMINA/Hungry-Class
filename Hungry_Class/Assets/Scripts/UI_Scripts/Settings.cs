using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;
    public Toggle musicToggle;
    public Toggle soundToggle;
    [SerializeField]private GameObject settingsScreen;

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
            AudioManager._instance.Play("BackgroundMusic");
        else
            AudioManager._instance.Stop("BackgroundMusic");
       
    }
    
    public void ToggleSound()
    {
        if (soundToggle.isOn)
            audioMixer.SetFloat("SFX_Volume", 0);
        else
            audioMixer.SetFloat("SFX_Volume",-80);
    }

    public void ExitSettings()
    {
        AudioManager._instance.Play("ClickSound");
        settingsScreen.SetActive(false);
    }
  
}
