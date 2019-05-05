using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float safeBoundary = 0.05f;
    private GameObject parent;
    public float limit = 10;
    public float angleLim = 60;
    private Vector3 limP;
    private Vector3 limN;
    public float stickLength = 1.0f;
    // Start is called before the first frame update
    void Start(){
        parent = transform.parent.gameObject;
        transform.Translate(parent.transform.position + stickLength* Vector3.up);
    }

    float sig(float val, float lim){
        if (val> lim){
            return 1.0f;
        }
        if (val < -lim){
            return -1.0f;
        }
        return 0f;
    }
    // Update is called once per frame
    void Update()
    {   float x,y;
        System.Console.WriteLine(Input.mousePosition);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        x = objPosition.x - parent.transform.position.x;
        y = objPosition.y - parent.transform.position.y;
        Vector3 dir = new Vector3(x,y,0);
        Vector3 diff = transform.position - parent.transform.position;
        diff.z = 0;
        float angle = Vector3.SignedAngle(diff, dir, Vector3.forward);
        float angleY = Vector3.SignedAngle(Vector3.up,dir,Vector3.forward);
        float currentAngle =- Vector3.SignedAngle(diff,Vector3.up,Vector3.forward);
        // if ( angleY > angleLim){
        //     // angle = Vector3.SignedAngle(diff,)
        // }
        // Debug.Log("Angle is "  + angle + " " + angleY + " "+ currentAngle);
        float t = Time.deltaTime;
        
        if (Input.GetButton("Fire2")){
            transform.RotateAround(parent.transform.position,Vector3.forward,sig(Vector3.SignedAngle(diff,Vector3.up,Vector3.forward),limit) * rotationSpeed * t);
        }
        else{
            if (angleY > angleLim){
                angle = angleLim - currentAngle;
            }
            if (angleY < -angleLim){
                angle = -angleLim - currentAngle;
            }
            // Debug.Log("Changed anlge:" + angle);
        if(angle > limit){
            if (rotationSpeed*t > angle)
                // transform.RotateAround(parent.transform.position,Vector3.forward,angle );
                Debug.Log("Do Nothing");
            else
                transform.RotateAround(parent.transform.position,Vector3.forward,rotationSpeed *t );
        }
        if(angle <-limit){
            if (rotationSpeed*t > -angle)
            // transform.RotateAround(parent.transform.position,Vector3.forward,angle );
            Debug.Log("Do nothing");
            else
            transform.RotateAround(parent.transform.position,Vector3.forward,- rotationSpeed *t );
        }
        }
        if (Vector3.Distance(transform.position, parent.transform.position) != stickLength){
            // Debug.Log(":OOOPS");

        }

    }
}
