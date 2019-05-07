using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class levelcompletion : MonoBehaviour
{
    public GameManagerScript gm;

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "player"){
            Debug.Log("Triggered");
            gm.levelcomplete();
        }   
    }
}
