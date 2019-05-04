using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public GameObject player;
    public float cameraSpeed;
    public int hintNum;
    private int hintsgiven;
    public float hintTimeout;
    private float hinttime;
    public Color hcolor;
    public int zoom;
    public int stdzoom;
    private Color stdcolor = Color.black;
    private Camera cam;
    public float dimensionX,dimensionY;
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = player.transform.position;
        // transform.position.z = -10;
        cam = GetComponent<Camera>();
        hintsgiven = 0;
        hinttime = -100;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.H)){
            if(hintsgiven < hintNum){
                cam.backgroundColor = hcolor;
                cam.orthographicSize = zoom;
                hinttime = Time.time;
                hintsgiven += 1;
            }
            else{
                Debug.Log("Consumed all hints");
            }
        }
        if(Time.time > hinttime + hintTimeout){
            cam.orthographicSize = stdzoom;
            cam.backgroundColor = stdcolor;
        }
        float dirx = 0f, diry = 0f;
        if( Mathf.Abs(player.transform.position.x - transform.position.x) > dimensionX){
            if(player.transform.position.x > transform.position.x){
                dirx = -1.0f;
            }
            else
                dirx = 1.0f;
        }
        if( Mathf.Abs(player.transform.position.y - transform.position.y) > dimensionY){
            if(player.transform.position.y > transform.position.y){
                diry = -1.0f;
            }
            else
                diry = 1.0f;
        }
        transform.position += (transform.up *(-dirx) + transform.up *(-diry))* cameraSpeed * Time.deltaTime;
    }
}
