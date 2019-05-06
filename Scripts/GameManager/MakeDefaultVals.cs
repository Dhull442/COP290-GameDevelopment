using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeDefaultVals : MonoBehaviour
{

    public void SetDefaults() {
        Slider musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        Slider fxSlider = GameObject.Find("MasterSlider").GetComponent<Slider>();
        Slider keyboardSlider = GameObject.Find("KeyboardSlider").GetComponent<Slider>();
        float musicDef = 0.5f;
        float fxDef = 0.5f;
        float keyboardDef = 0.5f;
        musicSlider.value = musicDef;
        fxSlider.value = fxDef;
        keyboardSlider.value = keyboardDef;
    }
}
