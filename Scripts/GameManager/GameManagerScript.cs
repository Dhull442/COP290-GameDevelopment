using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject levelcompleteUI;
    
    public GameObject levelfailedUI;

    public GameObject pauseMenuUI;
    public float timeLimit;
    private float startTime;
    public Slider timebar;
    public Image fill;
    public Color endcolor;
    public Color startcolor;
    private AudioSource musicSource;

    public Slider music;
    public Slider master;

    private bool isPaused = false;
    public Button resumeButton;

    public void Start() {
        Time.timeScale = 1;
        startTime = Time.timeSinceLevelLoad;
        dataHandler.LoadData();
        musicSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        musicSource.volume = dataHandler.tmp.musicVolume;
        AudioListener.volume = dataHandler.tmp.masterVolume;
        music.value = musicSource.volume;
        master.value = AudioListener.volume;
    }
    void Update()
    {
        float timeleft = timeLimit - (startTime + Time.timeSinceLevelLoad);
        if(timeleft <= 0)
        {
            levelfailed();
        }
        timebar.value = timeleft / timeLimit;
        //Debug.Log("timber = " + timeleft / timeLimit);
        float value = (timeleft / timeLimit);
        fill.color = value * startcolor + (1 - value) * endcolor;

        pausing();
    }

    public void penalise(float fac)
    {
        startTime += fac*timeLimit;
    }
    public void levelcomplete(){
        //Debug.Log("YOUR LEVLE DONE");
        int lvl = SceneManager.GetActiveScene().buildIndex;
        if (dataHandler.tmp.levelQual <= lvl)
        {
            dataHandler.tmp.levelQual = lvl;
            dataHandler.SaveData();
        }
        levelcompleteUI.SetActive(true);
        //loadNextLevel();
    }

    public void levelfailed(){
        Debug.Log("Time Limit Exceeded");
        Time.timeScale = 0;
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
        if(isPaused){
                resumeButton = GameObject.Find("ResumeBtn").GetComponent<Button>();
                resumeButton.onClick.AddListener(unpause);
        }
    }
    public void unpause(){
        Debug.Log("UNPAUSE CALLED");
        pauseMenu(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void loadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1 ){
            Debug.Log("You Have Completed game");
            SceneManager.LoadScene(0);
        }
        else{
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
           
        }     
    }
}
