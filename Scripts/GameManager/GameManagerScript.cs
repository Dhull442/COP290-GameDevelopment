using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject levelcompleteUI;
    public GameObject levelfailedUI;
    public void levelcomplete(){
        Debug.Log("YOUR LEVLE DONE");
        levelcompleteUI.SetActive(true);
        loadNextLevel();
    }

    public void levelfailed(){
        Debug.Log("Time Limit Exceeded");
        levelfailedUI.SetActive(true);
        // Handlers
    }

    void loadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1 ){
            Debug.Log("You Have Completed game");
            SceneManager.LoadScene(0);
        }
        else{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }     
    }
}
