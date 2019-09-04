using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files

public class DataController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public string name;
        public int lives;
        public float health;

        public static PlayerInfo CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PlayerInfo>(jsonString);
        }

        // Given JSON input:
        // {"name":"Dr Charles","lives":3,"health":0.8}
        // this example will return a PlayerInfo object with
        // name == "Dr Charles", lives == 3, and health == 0.8f.
    }
    private void Start()
    {
    }
}