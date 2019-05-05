﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   

    AudioSource source;
    AudioSource rotationSource;

    AudioSource movementSource;

    AudioSource harmSource;

    AudioSource expansionSource;
    public AudioClip[] clips;
    public AudioClip[] stickclips;

    public AudioClip[] movementClips;
    public AudioClip[] rotationclips;
    public AudioClip[] expansionclips;
    public AudioClip[] harmClips;

    public Material[] materials;
    // private Collider coll;
    private float timeOfCollision = -100.0f;
    public float timeout = 1.0f;
    public float timePenalty = 1.5f;
    public bool movingObstacle;
    public float movementAcceleration = 1.0f; // SHM movement
    private Vector3 centerposition;
    public float movementBound = 1.0f;
    public bool VerticalMovement;
    public bool harmfulObstacle;
    public bool expandable;
    private bool expand; // set true then expand to max;
    private float expansionStartTime;
    public float expandTime = 5; /// in seconds
    private bool expansionDone=false;
    public float[] dimLimits= {2.0f,2.0f}; // Dimension Limits for Expansion 

    public bool rotatingObstacle;
    public float rotationSpeed = 100f;

    private Vector3 originalSize;

    Renderer rend;
    void OnCollisionEnter(UnityEngine.Collision coll){
        if(coll.gameObject.tag == "stick"){
            if(harmfulObstacle){
                harmSource.clip = harmClips[Random.Range(0,harmClips.Length-1)];
                harmSource.Play();
                rend.sharedMaterial = materials[2];
            }
            else{
            source.clip = stickclips[Random.Range(0,stickclips.Length -1)];
            source.Play();
            rend.sharedMaterial = materials[1];
            }
            // Debug.Log("Collision with stick");                
            if(expandable  && !(expansionDone || expand)){
                expand = true;
                expansionStartTime = Time.time;
            }
            timeOfCollision = Time.time;
        }
        if(coll.gameObject.tag=="player"){
        if(harmfulObstacle){
            if(!harmSource.isPlaying){
                harmSource.clip = harmClips[Random.Range(0,harmClips.Length-1)];
                harmSource.Play();
            }
            // Time Penalty here
        }
        else{
            if(!source.isPlaying){
                source.clip = clips[Random.Range(0,clips.Length -1 )];
                source.Play();
            }
        }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        // source = GetComponent<AudioSource> ();
        centerposition = transform.position;
        expand = false;
        originalSize =GetComponent<BoxCollider>().bounds.size;
        source = GetComponents<AudioSource>()[0];
        expansionSource = GetComponents<AudioSource>()[1];
        harmSource = GetComponents<AudioSource>()[2];
        movementSource = GetComponents<AudioSource>()[3];
        rotationSource = GetComponents<AudioSource>()[4];
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
            if(!movementSource.isPlaying){
                movementSource.clip= movementClips[Random.Range(0,movementClips.Length -1 )];
                movementSource.Play();
            }
        }
        if(expand){
            if(Time.time > expansionStartTime + expandTime){
                expansionDone = true;
                expand = false;
                expansionSource.Stop();
            }
            float changeamt = (Time.time - expansionStartTime)/expandTime;
            Vector3 targetscale = (dimLimits[0] -1.0f)*originalSize.x*Vector3.right + (dimLimits[1]-1.0f)*originalSize.y*Vector3.up ;
            
            // add music as well;
            transform.localScale = changeamt* targetscale + originalSize;
            if(!expansionSource.isPlaying){
                expansionSource.clip= expansionclips[Random.Range(0,expansionclips.Length -1 )];
                expansionSource.Play();
            }
        }
        if(rotatingObstacle){
            transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
            if(!rotationSource.isPlaying){
                rotationSource.clip = rotationclips[Random.Range(0,rotationclips.Length -1)];
            }
        }
    }
}
