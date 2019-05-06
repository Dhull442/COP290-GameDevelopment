using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gotoLevel : MonoBehaviour
{
    public Button[] lvlBtns;
    
    public void TaskOnClick(int lvlNo) {
        Debug.Log("Goto Level" + lvlNo.ToString());
        // SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        lvlBtns = new Button[15];
        for(int j = 0; j < 15; j++) {
            int lvlNo = j + 1;
            string btnName = "BtnLvl" + lvlNo.ToString();
            Debug.Log(btnName);
            lvlBtns[j] = GameObject.Find(btnName).GetComponent<Button>();   
            lvlBtns[j].onClick.AddListener(delegate {TaskOnClick(lvlNo);});
        }
    }
}
