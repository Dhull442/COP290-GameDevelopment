using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMovement : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float safeBoundary = 0.05f;
    private float currentstickLength;
    private GameObject parent;
    public float limit = 10;
    public float angleLim = 60;
    private Vector3 limP;
    private Vector3 limN;
    private Rigidbody rb;
    private float tmpStickLength;
    public float stickLength = 1.0f;
    public float minStickLength = 0.25f ;
    private float scale = 1.5f;
    private float lengthSpeed = 0.3f;
    
    // Start is called before the first frame update
    void Start(){
        parent = transform.parent.gameObject;
        Quaternion angle = new Quaternion(0,0,0,0);
        transform.SetPositionAndRotation(parent.transform.position + (stickLength/2.0f)* parent.transform.up, Quaternion.identity);
        transform.localScale = 0.125f * stickLength * Vector3.up + 0.5f * Vector3.right + Vector3.forward;
        currentstickLength =  stickLength;
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

    float mysig(float val, float lim)
    {
        if (val > lim)
        {
            return 1.0f;
        } else
        {
            return -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 dir = objPosition- transform.position; dir.z = 0;
        Vector3 diff = objPosition - transform.position;diff.z = 0;

        //Debug.Log("SCALE: " + scale.ToString());
        //Debug.Log("ORG: " + transform.position.magnitude.ToString());
        //Debug.Log("DIFF: " + (diff.magnitude/scale).ToString());
        //if (diff.magnitude / scale > stickLength)
        //{
        //    Debug.Log("CALC LENGTH GREATER THAN MAX");
        //    tmpStickLength = stickLength;
        //}
        //else if (diff.magnitude / scale < minStickLength)
        //{
        //    Debug.Log("CALC LENGTH LESSER THAN MIN");
        //    tmpStickLength = minStickLength;
        //}
        //else
        //{
        //    Debug.Log("CALC LENGTH SETTINg");
        //    tmpStickLength = diff.magnitude / scale;
        //}
        ////Debug.Log("TMP STICK: " + tmpStickLength.ToString());
        //if (Mathf.Abs(tmpStickLength - currentstickLength) < lengthSpeed)
        //{
        //    Debug.Log("DIRECT");
        //    currentstickLength = tmpStickLength;
        //} else {
        //    Debug.Log("Changing: " + (mysig(tmpStickLength, currentstickLength) * lengthSpeed).ToString());
        //    currentstickLength += mysig(tmpStickLength, currentstickLength) * lengthSpeed;
        //}

        float currentAngle = transform.eulerAngles.z;
        if (currentAngle>180){
            currentAngle -= 360;
        }
        float angle = Vector3.SignedAngle(parent.transform.up,dir,Vector3.forward) - currentAngle;
        float t = Time.deltaTime;
        if(angle > limit){
            rb.AddTorque( rotationSpeed * angle/angleLim * Vector3.forward);
        }
        if(angle <-limit){
            rb.AddTorque( rotationSpeed * (angle/angleLim )*  Vector3.forward);
        }



        float change = Input.GetAxis("Mouse ScrollWheel") * scale;
        bool changelength = false;
        if (change > 0.05f)
        {
            if (currentstickLength + scale * change < stickLength)
            {
                currentstickLength += scale * change;
            }
            else
            {
                currentstickLength = stickLength;
            }
            changelength = true;
        }
        if (change < -0.05f)
        {
            changelength = true;
            if (currentstickLength + scale * change > minStickLength)
            {
                currentstickLength += scale * change;
            }
            else
            {
                currentstickLength = minStickLength;
            }
        }
        if (changelength)
            transform.localScale = 0.125f * currentstickLength * Vector3.up + 0.5f * Vector3.right + Vector3.forward;
    }
}
