//This must be added to consider this script not as MonoBehaviour, but as file data handler
[System.Serializable]
public class PlayerData
{
    public int record;

    //PlayerData is the class used for operation of reading/writing data
    //The data that I want to read/save is the variable "public int score"" in the GameManager script
    //"points" is just a random name for the local GameManager type
    public PlayerData(int points)
    {
        //To access "record", use "PlayerData data.record" in the level1 script
        record = points;
    }
}