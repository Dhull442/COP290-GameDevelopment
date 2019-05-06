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
    private Rigidbody rb;
    public float stickLength = 1.0f;
    // Start is called before the first frame update
    void Start(){
        parent = transform.parent.gameObject;
        Quaternion angle = new Quaternion(0,0,0,0);
        transform.SetPositionAndRotation(parent.transform.position + (stickLength/2.0f)* parent.transform.up, Quaternion.identity);
        transform.localScale = 0.125f * stickLength * Vector3.up + 0.5f * Vector3.right + Vector3.forward;
        rb = GetComponent<Rigidbody>();

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
        // float angle = Vector3.SignedAngle(diff, dir, Vector3.forward);
        float angle;
        float angleY = Vector3.SignedAngle(parent.transform.up,dir,Vector3.forward);
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle>180){
            currentAngle -= 360;
        }
        angle = angleY - currentAngle;
        Debug.Log("Angle is "  + angle + " " + angleY + " "+ currentAngle);
        float t = Time.deltaTime;
        if (Input.GetButton("Fire2")){
            transform.RotateAround(parent.transform.position,Vector3.forward,sig(Vector3.SignedAngle(diff,parent.transform.up,Vector3.forward),limit) * rotationSpeed * t);
            
        }
        // else{
        //     if (angleY > angleLim){
        //         angle = angleLim - currentAngle;
        //     }
        //     if (angleY < -angleLim){
        //         angle = -angleLim - currentAngle;
        //     }
        if(angle > limit){
            rb.AddTorque( rotationSpeed * angle/angleLim * Vector3.forward);
        }
        if(angle <-limit){
            rb.AddTorque( rotationSpeed * (angle/angleLim )*  Vector3.forward);
        }
        
        // if (Vector3.Distance(transform.position, parent.transform.position) != stickLength){
        //     // Debug.Log(":OOOPS");

        // }
        diff = transform.position - parent.transform.position;
        // transform.Translate()
    }
}
