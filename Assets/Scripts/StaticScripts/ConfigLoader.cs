using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System.Text;
using UnityEditor;
using SimpleJSON;

[System.Serializable]
public class ConfigLoader : MonoBehaviour
{

    /*Config Params*/
    public static string jsonData;

    //Pulic trigers
    public static int gameAreaWidth;
    public static int gameAreaHeight;
    public static  int unitSpawnDelay;
    public static  int numUnitsToSpawn;
    public static float minUnitRadius;
    public static float maxUnitRadius;
    public static float minUnitSpeed;
    public static float maxUnitSpeed;
        
       

    static void ReadString()
    {
        string path = Application.dataPath + "/StreamingAssets/json.txt";
        //Read the text from directly from the path file
        StreamReader reader = new StreamReader(path);
        jsonData = reader.ReadToEnd();
        reader.Close();
    }

    public static void ReadConfig()
    {
        ReadString();

        JSONNode jsonNode = SimpleJSON.JSON.Parse(jsonData);
        gameAreaWidth = jsonNode["GameConfig"]["gameAreaWidth"];
        gameAreaHeight = jsonNode["GameConfig"]["gameAreaHeight"];
        unitSpawnDelay = jsonNode["GameConfig"]["unitSpawnDelay"];
        numUnitsToSpawn = jsonNode["GameConfig"]["numUnitsToSpawn"];
        minUnitRadius = jsonNode["GameConfig"]["minUnitRadius"];
        maxUnitRadius = jsonNode["GameConfig"]["maxUnitRadius"];
        minUnitSpeed = jsonNode["GameConfig"]["minUnitSpeed"];
        maxUnitSpeed = jsonNode["GameConfig"]["maxUnitSpeed"];
    }



}
