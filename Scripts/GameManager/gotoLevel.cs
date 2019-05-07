using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gotoLevel : MonoBehaviour
{
    public Button[] lvlBtns;
    public Slider musicSlider;
    public Slider masterSlider;
    public Slider sensitivitySlider;
    
    public void TaskOnClick(int lvlNo) {
        Debug.Log("Goto Level" + lvlNo.ToString());
        // SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        SceneManager.LoadScene((lvlNo));
    }

    // Start is called before the first frame update
    void Start()
    {
        //lvlBtns = new Button[15];
        for(int j = 0; j < 15; j++) {
            int lvlNo = j + 1;
            string btnName = "BtnLvl" + lvlNo.ToString();
            Debug.Log(btnName);
            lvlBtns[j].onClick.AddListener(delegate {TaskOnClick(lvlNo);});
        }
        
    }
    private void Update()
    {
        dataHandler.LoadData();
        musicSlider.value = dataHandler.tmp.musicVolume;
        masterSlider.value = dataHandler.tmp.masterVolume;
        for (int i = 0; i < 15; i++)
        {
            if (i > dataHandler.tmp.levelQual)
            {
                lvlBtns[i].enabled = false;
            }
            else
                lvlBtns[i].enabled = true;
        }
    }
}
