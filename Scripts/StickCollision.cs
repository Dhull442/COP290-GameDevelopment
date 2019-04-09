using UnityEngine;

public class StickCollision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision obj){
        Debug.Log(obj.collider.name);

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stick Collider Script enabled");   
    }

    // // Update is called once per frame
    void Update()
    {
        
    }
}
