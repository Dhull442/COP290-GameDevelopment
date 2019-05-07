using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using unit
public static class dataHandler 
{   
    public static string path = "C:/Users/Public/Documents/player.binary";
    public static PlayerData tmp = new PlayerData(0,0.5f,0.5f,0);

    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Debug.Log(path);
        FileStream stream;
        if(File.Exists(path))
            stream = new FileStream(path, FileMode.Open);
        else
        {

            stream = new FileStream(path, FileMode.CreateNew);
        }
        formatter.Serialize(stream, tmp);
        stream.Close();
    }
    public static PlayerData LoadData()
    {
        //FileStream 
        tagain:
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            tmp = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            //return read;
        }
        else
        {
            SaveData();
            goto tagain;
        }
        return tmp;
    }
}
