using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public GameManager Gm;
    public class MyClass
    {
        public int gameAreaWidth;
        public int gameAreaHeight;
        public Vector2[] PositionNow;
        public Vector2[] VectorsNow;
    }
   

    public void SaveState()
    {
        MyClass myObject = new MyClass();
        myObject.gameAreaWidth = ConfigLoader.gameAreaWidth;
        myObject.gameAreaHeight = ConfigLoader.gameAreaHeight;
        print(Gm.RedTeam.Count);
        for (int i = 0; i < Gm.RedTeam.Count; i++)
        {
            print(Gm.RedTeam[i].name);
            myObject.PositionNow[i] = new Vector2( Gm.RedTeam[i].transform.position.x, Gm.RedTeam[i].transform.position.y);
        }

        string json = JsonUtility.ToJson(myObject);
        print(json);
    }


}





