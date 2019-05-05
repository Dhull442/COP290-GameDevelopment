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

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "player"){
            Debug.Log("Triggered");
            gm.levelcomplete();
        }   
    }

    void Start(){
        startTime= Time.time;
    }

    void Update(){
        if(Time.time > startTime+timeLimit){
            Debug.Log("LEVEL FAILED");
            gm.levelfailed();
        }
        panel.GetComponentInChildren<Text>().text = ("Time : "+Mathf.FloorToInt(timeLimit - (startTime + Time.time)));
        // Debug.Log(Time.time);
    }

}
