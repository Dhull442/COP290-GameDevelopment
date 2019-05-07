using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    AudioSource source;
    public AudioClip[] clips; 
    public float speed =1.0f;
    public float speedup = 2;
    bool walking = false;
    float currentspeed ;
    public string axis1 = "Horizontal";
    public string axis2 = "Vertical";
    private Rigidbody rb;
    public Animator animL,animR;
    public string[] left, right;
    private int orientation;
    // public Animator anim;

    // Use this for initialization
    void Start () {
        // anim = gameObject.GetComponent<Animator> ();
        currentspeed = speed;
        source = GetComponent<AudioSource>();
        //animL.Play("walkinLeft");
        //animR.Play("walking");
        rb = GetComponent<Rigidbody>();

        orientation = 0;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        // Debug.Log("Player position : "+transform.position);
        walking = false;
        // anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis(axisName)));
        float hin = Input.GetAxis(axis1), vin = Input.GetAxis(axis2);
        if (hin != 0||vin!=0)
        {
                // Vector3 newScale = transform.localScale;
                // newScale.y = 1.0f;
                // newScale.x = 1.0f;
                // transform.localScale = newScale;
                
                walking = true;
        } 

        // else if (Input.GetAxis (axis1) > 0)
        // {
        //         Vector3 newScale =transform.localScale;
        //         newScale.x = 1.0f;
        //         transform.localScale = newScale; 
        //         walking = true;       
        // }
        // if (Input.GetAxis (axis2) < 0)
        // {
        //         // Vector3 newScale = transform.localScale;
        //         // newScale.y = 1.0f;
        //         // newScale.x = 1.0f;
        //         // transform.localScale = newScale;
        //         walking = true;
        // } 
        // else if (Input.GetAxis (axis2) > 0)
        // {
        //         Vector3 newScale =transform.localScale;
        //         newScale.y = 1.0f;
        //         transform.localScale = newScale;      
        //         walking = true;  
        // }

        if (orientation == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; ;
        } else if (orientation == 1) {
            // Make the character face towards left
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; ;
        } else if (orientation == 2)
        {
            // Make the character face downwards
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; ;
        } else if (orientation == 3)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

        if (vin != 0)
        {
            if (vin > 0)
            {
                orientation = 0;
            } else
            {
                orientation = 2;
            }
        } else if (hin != 0)
        {
            if (hin > 0)
            {
                orientation = 1;
            } else
            {
                orientation = 3;
            }
        }

        if ( Input.GetButton("Fire1")){
                currentspeed = speedup*speed;
        }
        else{
                currentspeed = speed;
        }
        
        rb.AddForce(100000*(vin*Vector3.up + hin*Vector3.right)*currentspeed);
        // transform.position += (transform.right *Input.GetAxis(axis1) + transform.up *Input.GetAxis(axis2))* currentspeed * Time.deltaTime;
        
        if(! walking ) {
                source.Pause();
                animL.enabled = false;
                animR.enabled = false;
        }
        if(!source.isPlaying && walking){
                source.clip = clips[Random.Range(0,clips.Length)];
                source.Play();
        }
        if(walking){
            if(orientation == 2)
            {
                animL.Play(left[0]);

                animR.Play(right[0]);
            }
            else
            {   if (orientation == 3)
                {
                    animL.Play(left[2]);
                    animR.Play(right[2]);
                }
                else
                {
                    animL.Play(left[orientation]);
                    animR.Play(right[orientation]);
                }
            }
                animL.enabled = true;
                animR.enabled = true;
        }
        

    }
}
