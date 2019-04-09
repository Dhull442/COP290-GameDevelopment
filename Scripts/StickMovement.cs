using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float safeBoundary = 0.05f;
    public GameObject parent;
    public float stickLength = 1.0f;
    float centerx = Screen.width/2.0f, centery = Screen.height/2.0f;
    // Start is called before the first frame update
    void Start(){
    
    }

    // Update is called once per frame
    void Update()
    {   float x,y;
        System.Console.WriteLine(Input.mousePosition);
        x = Input.mousePosition.x - centerx;
        y = Input.mousePosition.y - centery;
        float t = Time.deltaTime;
        float d = Vector3.Distance(transform.position + (transform.right *(x)/centerx + transform.up *(y)/centery)* rotationSpeed * t,parent.transform.position); 
             
        if (Input.GetButton("Fire1")){
            if((d) < stickLength )
            {transform.position += (transform.right *(x)/centerx + transform.up *(y)/centery)* rotationSpeed * t;}
        }
        if(Input.GetButton("Fire2")){
            if(transform.position.x - parent.transform.position.x > safeBoundary){
                x = -1.0f;
            }
            else if(transform.position.x - parent.transform.position.x < -safeBoundary)
                x = 1.0f;
            else
                x = 0;

            if(transform.position.y - parent.transform.position.y > safeBoundary){
                y = -1.0f;
            }
            else if(transform.position.y - parent.transform.position.y < -safeBoundary)
                y = 1.0f;
            else
                y = 0;

            transform.position+= (transform.right*x + transform.up*y)*rotationSpeed*t;
        }
    }
}
