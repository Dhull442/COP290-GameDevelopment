using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    //public float[] leveldata;
    public int levelQual;
    public float musicVolume;
    public float masterVolume;
    public float hintsLeft;
    public PlayerData(int levs,float mv,float mastv,int hints)
    {
        this.levelQual = levs;
        this.masterVolume = mastv;
        this.musicVolume = mv;
        this.hintsLeft = hints;
    }
    public PlayerData empytplayerdata()
    {
        PlayerData tmp = new PlayerData(0, 0.5f, 0.5f, 0);
        return tmp;
    }

    public void reset()
    {
        this.levelQual = 0;
        this.hintsLeft = 0;
    }
}