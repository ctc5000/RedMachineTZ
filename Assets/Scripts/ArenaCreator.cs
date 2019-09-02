using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCreator : MonoBehaviour
{
    public GameObject Arena;

    private void Start()
    {
        ConfigLoader.ReadConfig();
        ArenaGenerator();
    }

    public void ArenaGenerator()
    {
        GameObject _Arena = Instantiate<GameObject>(Arena);
        _Arena.transform.localScale = new Vector3(ConfigLoader.gameAreaWidth, ConfigLoader.gameAreaHeight,0);
    }
  
}
