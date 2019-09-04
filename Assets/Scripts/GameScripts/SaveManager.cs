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
        public List<Vector2> RedPositionNow;
        public List<float> Redspeed;
        public List<Vector2> RedVectorsNow;
        public List<Vector2> RedScale;
        public List<float> Bluespeed;
        public List<Vector2> BluePositionNow;
        public List<Vector2> BlueVectorsNow;
        public List<Vector2> BlueScale;
        public string TimeSimulate;
    }
   

    public void SaveState()
    {
        MyClass myObject = new MyClass();
        myObject.gameAreaWidth = ConfigLoader.gameAreaWidth;
        myObject.gameAreaHeight = ConfigLoader.gameAreaHeight;
        //Write red Team
        List<float> Redspeed = new List<float> {};
        List<Vector2> RedPositionNow = new List<Vector2> {};
        List<Vector2> RedVectorsNow = new List<Vector2> {};
        List<Vector2> RedScale = new List<Vector2> {};

        for (int i = 0; i < Gm.RedTeam.Count; i++)
        {
            Redspeed.Add(Mathf.Round(Gm.RedTeam[i].GetComponent<ball2>().speed));
            RedPositionNow.Add(Gm.RedTeam[i].transform.position);
            RedVectorsNow.Add(new Vector2(Gm.RedTeam[i].GetComponent<ball2>().moveX, Gm.RedTeam[i].GetComponent<ball2>().moveY));
            RedScale.Add(Gm.RedTeam[i].transform.localScale);

        }
        myObject.Redspeed = Redspeed;
        myObject.RedPositionNow = RedPositionNow;
        myObject.RedVectorsNow = RedVectorsNow;
        myObject.RedScale = RedScale;

        //Write blue Team
        List<float> Bluespeed = new List<float> { };
        List<Vector2> BluePositionNow = new List<Vector2> { };
        List<Vector2> BlueVectorsNow = new List<Vector2> { };
        List<Vector2> BlueScale = new List<Vector2> { };

        for (int i = 0; i < Gm.BlueTeam.Count; i++)
        {
            Bluespeed.Add(Mathf.Round(Gm.BlueTeam[i].GetComponent<ball2>().speed));
            BluePositionNow.Add(Gm.BlueTeam[i].transform.position);
            BlueVectorsNow.Add(new Vector2(Gm.BlueTeam[i].GetComponent<ball2>().moveX, Gm.BlueTeam[i].GetComponent<ball2>().moveY));
            BlueScale.Add(Gm.BlueTeam[i].transform.localScale);

        }
        myObject.Bluespeed = Bluespeed;
        myObject.BluePositionNow = BluePositionNow;
        myObject.BlueVectorsNow = BlueVectorsNow;
        myObject.BlueScale = BlueScale;

        //Time simulate write
        myObject.TimeSimulate = Mathf.Round(GameObject.Find("Time").GetComponent<TimeSimulate>().time).ToString();



        string json = JsonUtility.ToJson(myObject);
        PlayerPrefs.SetString("Save", json);
        PlayerPrefs.Save();
    }


}





