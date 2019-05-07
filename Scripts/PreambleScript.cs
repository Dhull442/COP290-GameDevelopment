using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreambleScript : MonoBehaviour
{

    public Text preambleDisplay;
    public float preambleTimeout = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > preambleTimeout)
        {
            preambleDisplay.text = "";
        }
    }
}
