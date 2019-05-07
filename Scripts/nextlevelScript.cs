using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextlevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManagerScript gm;
    public void gotoNext()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        gm.loadNextLevel();
    }
}
