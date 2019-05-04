using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcompletion : MonoBehaviour
{
    public GameManagerScript gm;
    public float timeLimit;
    private float startTime;
    // void OnCollisionEnter(UnityEngine.Collision coll){
    //     if(coll.gameObject.tag == "player"){
    //         Debug.Log("Level Complete");
    //         // Level Completion scripts
    //     }
    // }

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
        Debug.Log(Time.time);
    }

}
