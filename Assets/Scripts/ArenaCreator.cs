using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCreator : MonoBehaviour
{
    public GameObject ArenaPrefab;

    private void Start()
    {
     //   ConfigLoader.ReadConfig();
       // ArenaGenerator();
    }

    public static GameObject ArenaGenerator(GameObject ArenaPrefab)
    {
        GameObject _Arena = Instantiate<GameObject>(ArenaPrefab);
        _Arena.transform.localScale = new Vector3(ConfigLoader.gameAreaWidth, ConfigLoader.gameAreaHeight,0);
        // GetComponent<BallsGenerator>().BallsGenerate(_Arena);
        return _Arena;
    }
  
}
