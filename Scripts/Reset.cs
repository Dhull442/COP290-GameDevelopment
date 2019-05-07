using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    
    public void resetProg()
    {
        dataHandler.tmp.reset();
        dataHandler.SaveData();
    }
}
