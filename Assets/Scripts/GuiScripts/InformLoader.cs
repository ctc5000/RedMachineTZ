using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InformLoader : MonoBehaviour
{
    public List<GameObject> Texts;
    private void Start()
    {
        ConfigLoader.ReadConfig();
        Texts[0].GetComponent<Text>().text = ConfigLoader.gameAreaWidth.ToString();
        Texts[1].GetComponent<Text>().text = ConfigLoader.gameAreaHeight.ToString();
        Texts[2].GetComponent<Text>().text = ConfigLoader.unitSpawnDelay.ToString();
        Texts[3].GetComponent<Text>().text = ConfigLoader.minUnitRadius.ToString();
        Texts[4].GetComponent<Text>().text = ConfigLoader.maxUnitRadius.ToString();
        Texts[5].GetComponent<Text>().text = ConfigLoader.minUnitSpeed.ToString();
        Texts[6].GetComponent<Text>().text = ConfigLoader.maxUnitSpeed.ToString(); 
        Texts[7].GetComponent<Text>().text = ConfigLoader.numUnitsToSpawn.ToString(); 
    }

}
