using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public GameObject player;
    public float cameraSpeed;
    private Camera cam;
    public float dimensionX,dimensionY;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        float dirx = 0f, diry = 0f;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) > dimensionX)
        {
            if (player.transform.position.x > transform.position.x)
            {
                dirx = -1.0f;
            }
            else
                dirx = 1.0f;
        }
        if (Mathf.Abs(player.transform.position.y - transform.position.y) > dimensionY)
        {
            if (player.transform.position.y > transform.position.y)
            {
                diry = -1.0f;
            }
            else
                diry = 1.0f;
        }
        transform.position += (Vector3.right * (-dirx) + Vector3.up * (-diry)) * cameraSpeed * Time.deltaTime;

    }
}
