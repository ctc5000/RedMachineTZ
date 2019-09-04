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
        _Arena.GetComponent<SampleSprite>().size = new Vector2(ConfigLoader.gameAreaWidth, ConfigLoader.gameAreaHeight);
        return _Arena;
    }
  
}
