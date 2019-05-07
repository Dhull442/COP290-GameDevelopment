using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolChange : MonoBehaviour
{
    public AudioSource musicSource;

    
    public void ChangeMusicVol() {
        // musicSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        musicSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Slider musicSlider = GetComponent<Slider>();
        dataHandler.tmp.musicVolume = musicSlider.value;
        dataHandler.SaveData();
        musicSource.volume = dataHandler.tmp.musicVolume;
        
    }

}