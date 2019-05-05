using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject levelcompleteUI;
    public GameObject levelfailedUI;

    public GameObject pauseMenuUI;

    private bool isPaused = false;
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

    void pauseMenu(bool enable){
        pauseMenuUI.SetActive(enable);
    }

    public void pausing(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Game Paused");
            if(!isPaused){
                Time.timeScale = 0;
                isPaused = true;
            }
            else{
                Time.timeScale = 1;
                isPaused = false;
            }
        }
        pauseMenu(isPaused);
    }
    public void Update(){
        pausing();
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
