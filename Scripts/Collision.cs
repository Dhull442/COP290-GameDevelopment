using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   

    AudioSource source;
    public AudioClip[] clips;
    public AudioClip[] stickclips;
    public Material[] materials;
    float timeOfCollision = -100.0f;
    public float timeout = 1.0f;
    Renderer rend;
    void OnCollisionEnter(UnityEngine.Collision coll){
        if(coll.gameObject.tag == "stick"){
            source.clip = stickclips[Random.Range(0,stickclips.Length -1)];
            source.Play();
            Debug.Log("Collision with stick");
            rend.sharedMaterial = materials[1];
            timeOfCollision = Time.time;
        }
        if(!source.isPlaying){
            source.clip = clips[Random.Range(0,clips.Length -1 )];
            source.Play();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        source = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfCollision + timeout){
            rend.sharedMaterial = materials[0];
        }
    }
}
