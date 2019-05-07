using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hintProvider : MonoBehaviour
{
    private Renderer rend;

    private int hintsgiven;
    public float hintNum;
    public float hintTimeout = 1.5f;
    public float preambleTimeout = 2.0f;
    private float hinttime = -100.0f;
    public Color hcolor;
    private Color setcolor;
    public Color stdcolor;
    public int zoom;
    public int stdzoom;
    public Text hintdisplay;

    //private float startTime = 
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        setcolor = stdcolor;
        dataHandler.LoadData();
        hintNum = 1 + dataHandler.tmp.hintsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hintsgiven < hintNum)
            {
                setcolor = hcolor;
                hinttime = Time.timeSinceLevelLoad;
                hintsgiven += 1;
                hintdisplay.text = (hintNum - hintsgiven) + " hints left";
                
                
            }
            else
            {
                Debug.Log("Consumed all hints");
            }
        }
        dataHandler.tmp.hintsLeft = hintNum - hintsgiven;
        dataHandler.SaveData();
        if (Time.timeSinceLevelLoad < hinttime + hintTimeout)
        {
            Color c = Color.Lerp(setcolor, stdcolor, (Time.timeSinceLevelLoad - hinttime) / hintTimeout);
            rend.material.color = c;
            rend.material.SetColor("_EmissionColor", c);// = Color.Lerp(setcolor, stdcolor, (Time.timeSinceLevelLoad - timeOfCollision) / timeout);
        }
        else
        {
            hintdisplay.text = "";
        }
        
    }
}
