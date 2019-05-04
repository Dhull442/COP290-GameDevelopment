using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   

    AudioSource source;
    public AudioClip[] clips;
    public AudioClip[] stickclips;
    public Material[] materials;
    private Collider coll;
    private float timeOfCollision = -100.0f;
    public float timeout = 1.0f;
    public float timePenalty;
    public bool movingObstacle;
    public float movementAcceleration; // SHM movement
    private Vector3 centerposition;
    public float movementBound;
    public bool VerticalMovement;
    public bool harmfulObstacle;
    public bool expandable;
    private bool expand; // set true then expand to max;
    private float expansionStartTime;
    public float expandTime;
    private bool expansionDone=false;
    public float[] dimLimits; // Dimension Limits for Expansion 

    private Vector3 originalSize;

    Renderer rend;
    void OnCollisionEnter(UnityEngine.Collision coll){
        if(coll.gameObject.tag == "stick"){
            source.clip = stickclips[Random.Range(0,stickclips.Length -1)];
            source.Play();
            Debug.Log("Collision with stick");
            if(harmfulObstacle){
                rend.sharedMaterial = materials[2];
            }
            else
                rend.sharedMaterial = materials[1];
            if(expandable  && !(expansionDone || expand)){
                expand = true;
                expansionStartTime = Time.time;
            }
            timeOfCollision = Time.time;
        }
        if(coll.gameObject.tag=="player"){
            
        if(!source.isPlaying){
            source.clip = clips[Random.Range(0,clips.Length -1 )];
            source.Play();
        }
        if(harmfulObstacle){
            // Time Penalty along with alert!
        }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        source = GetComponent<AudioSource> ();
        centerposition = transform.position;
        expand = false;
        coll = GetComponent<BoxCollider>();
        originalSize = coll.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeOfCollision + timeout){
            rend.sharedMaterial = materials[0];
        }
        if(movingObstacle){
            Vector3 dir;
            if(VerticalMovement){
                    dir = Vector3.up;
            }
            else{
                dir = Vector3.right;
            }
            float w = Mathf.Sqrt(movementAcceleration / movementBound);
            transform.Translate(centerposition + dir*movementBound*Mathf.Cos(w*Time.time) - transform.position);
        }
        if(expand){
            if(Time.time > expansionStartTime + expandTime){
                expansionDone = true;
                expand = false;
            }
            float changeamt = (Time.time - expansionStartTime)/expandTime;
            Vector3 targetscale = (dimLimits[0] -1.0f)*originalSize.x*Vector3.right + (dimLimits[1]-1.0f)*originalSize.y*Vector3.up ;
            
            // add music as well;
            transform.localScale = changeamt* targetscale + originalSize;
        }
    }
}
