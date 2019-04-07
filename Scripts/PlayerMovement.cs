using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

     
    public float speed =1.0f;
    public string axis1 = "Horizontal";
    public string axis2 = "Vertical";
    // public Animator anim;

    // Use this for initialization
    void Start () {
        // anim = gameObject.GetComponent<Animator> ();
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        // anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis(axisName)));
        if (Input.GetAxis (axis1) < 0)
        {
                Vector3 newScale = transform.localScale;
                newScale.y = 1.0f;
                newScale.x = 1.0f;
                transform.localScale = newScale;
        } 
        else if (Input.GetAxis (axis1) > 0)
        {
                Vector3 newScale =transform.localScale;
                newScale.x = 1.0f;
                transform.localScale = newScale;        
        }
        if (Input.GetAxis (axis2) < 0)
        {
                Vector3 newScale = transform.localScale;
                newScale.y = 1.0f;
                newScale.x = 1.0f;
                transform.localScale = newScale;
        } 
        else if (Input.GetAxis (axis2) > 0)
        {
                Vector3 newScale =transform.localScale;
                newScale.y = 1.0f;
                transform.localScale = newScale;        
        }

        transform.position += (transform.right *Input.GetAxis(axis1) + transform.up *Input.GetAxis(axis2))* speed * Time.deltaTime;

    }
}
