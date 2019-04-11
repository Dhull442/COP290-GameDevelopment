using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundarycollision : MonoBehaviour
{   

    AudioSource source;
    public AudioClip[] clips;
    void OnCollisionEnter(UnityEngine.Collision coll){
        if(coll.gameObject.tag == "player" || coll.gameObject.tag == "stick"){
            Debug.Log("Boundary is hit");
            // Play collision sound
            Debug.Log("Playing boundary collision sound");
            if(!source.isPlaying){
            source.clip = clips[Random.Range(0,clips.Length)];
            source.Play();
            }
            // Addforce scripts

            // Vector3 forcemag = new Vector3(0,-1,0);
            // coll.collider.attachedRigidbody.AddForce(forcemag);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
