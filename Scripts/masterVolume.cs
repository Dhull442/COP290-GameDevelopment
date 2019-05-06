using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class masterVolume : MonoBehaviour
{
    // Start is called before the first frame update
    // public AudioSource musicSource;

    
    public void ChangeMusicVol() {
        // musicSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        Slider musicSlider = GameObject.Find("MasterSlider").GetComponent<Slider>();
        // AudioListener.volume = musicSlider.value;
        AudioListener.volume = musicSlider.value;
    }

}
