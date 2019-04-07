using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public GameObject parent;
    public float stickLength = 1.0f;
    float centerx = Screen.width/2.0f, centery = Screen.height/2.0f;
    // Start is called before the first frame update
    void Start()
    {
        System.Console.WriteLine(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {   float x,y;
        System.Console.WriteLine(Input.mousePosition);
        x = Input.mousePosition.x - centerx;
        y = Input.mousePosition.y - centery;
         if (Input.GetButton("Fire1")){
             float t = Time.deltaTime;
             float d = Vector3.Distance(transform.position + (transform.right *(x)/centerx + transform.up *(y)/centery)* rotationSpeed * t,parent.transform.position); 
             if((d) < stickLength )
                {transform.position += (transform.right *(x)/centerx + transform.up *(y)/centery)* rotationSpeed * t;
                Debug.Log("Position Changing ");
                Debug.Log(d);
         }
         }
    }

    // float distance(Vector3 diff){
    // return Math.Sqrt(
    // Math.Pow(diff.x, 2f) +
    // Math.Pow(diff.y, 2f) +
    // Math.Pow(diff.z, 2f));
    // }
}
