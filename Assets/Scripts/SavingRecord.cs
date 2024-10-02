using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//This will be the file handler manager
public static class SavingRecord
{
    //SaveRecord is a random name for the method that will open/close the file where I want to store
    //my record. "int" because the file will only store 1 int, otherwise I could use the name of a class
    //like "Player" or "PlayerData" to access to all the things that I want to save
    public static void SaveRecord(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //This takes a path in the OS (regardless if Windows, Mac or Android) that doesn't change
        string path = Application.persistentDataPath + "record.hid";
        //"hid" is a random extension for the new binary file "score". You can choose any extension.

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(score);

        formatter.Serialize(stream, data);
        stream.Close();
        //to close the file after saving the new record
    }

    public static PlayerData LoadRecord()
    {
        string path = Application.persistentDataPath + "record.hid";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //Deserialize to change the file from binary to the previous readable format
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Debug.Log(path + "opened.");
            stream.Close();

            return data;
        }
        else
        {
            //Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}