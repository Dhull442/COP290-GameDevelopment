using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelcompletion : MonoBehaviour
{
    public GameManagerScript gm;
    public GameObject panel;
    public float timeLimit;
    private float startTime;
    public Slider timebar;
    public Image fill;

    public Color endcolor;
    public Color startcolor;

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "player"){
            Debug.Log("Triggered");
            gm.levelcomplete();
        }   
    }

    void Start(){
        Time.timeScale = 1;
        startTime = Time.timeSinceLevelLoad;
    }

    void Update(){
        if(Time.timeSinceLevelLoad > startTime+timeLimit){
            Debug.Log("LEVEL FAILED");
            gm.levelfailed();
        }
        float timeleft = timeLimit - (startTime + Time.timeSinceLevelLoad);
        timebar.value = timeleft/timeLimit;
        float value = (timeleft/timeLimit);
        fill.color =  value * startcolor + (1 - value)  * endcolor ;
    }

    public void penalise(float time){
        startTime += time;  
    }

}
