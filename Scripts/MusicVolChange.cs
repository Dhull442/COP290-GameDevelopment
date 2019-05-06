using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolChange : MonoBehaviour
{
    public AudioSource musicSource;

    
    public void ChangeMusicVol() {
        // musicSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        Slider musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        // AudioListener.volume = musicSlider.value;
        musicSource.volume = musicSlider.value;
    }

}