using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcompletion : MonoBehaviour
{
    public GameManagerScript gm;
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

}
