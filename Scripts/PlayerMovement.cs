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
    // public Animator anim;

    // Use this for initialization
    void Start () {
        // anim = gameObject.GetComponent<Animator> ();
        currentspeed = speed;
        source = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log("Player position : "+transform.position);
        walking = false;
        // anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis(axisName)));
        if (Input.GetAxis (axis1) < 0)
        {
                Vector3 newScale = transform.localScale;
                newScale.y = 1.0f;
                newScale.x = 1.0f;
                transform.localScale = newScale;
                walking = true;
        } 
        else if (Input.GetAxis (axis1) > 0)
        {
                Vector3 newScale =transform.localScale;
                newScale.x = 1.0f;
                transform.localScale = newScale; 
                walking = true;       
        }
        if (Input.GetAxis (axis2) < 0)
        {
                Vector3 newScale = transform.localScale;
                newScale.y = 1.0f;
                newScale.x = 1.0f;
                transform.localScale = newScale;
                walking = true;
        } 
        else if (Input.GetAxis (axis2) > 0)
        {
                Vector3 newScale =transform.localScale;
                newScale.y = 1.0f;
                transform.localScale = newScale;      
                walking = true;  
        }

        if( Input.GetKey(KeyCode.LeftShift)){
                currentspeed = speedup*speed;
        }
        else{
                currentspeed = speed;
        }
        transform.position += (transform.right *Input.GetAxis(axis1) + transform.up *Input.GetAxis(axis2))* currentspeed * Time.deltaTime;
        if(! walking ){
                source.Pause();
        }
        if(!source.isPlaying && walking){
                source.clip = clips[Random.Range(0,clips.Length)];
                source.Play();
        }
        

    }
}
