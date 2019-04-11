using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcompletion : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision coll){
        if(coll.gameObject.tag == "player"){
            Debug.Log("Level Complete");
            // Level Completion scripts
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
