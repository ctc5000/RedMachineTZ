using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class GameManager : MonoBehaviour
{
    public List<GameObject> RedTeam;
    public List<GameObject> BlueTeam;
    public GameObject ArenaPrefab;
    public GameObject GameArena;
    public GameObject WinPanel;
    bool StartGenerate;
    int GeneratedBalls;
    float TimeSpawn;
    bool win;
    bool mustCheck;
    void Start()
    {
        ConfigLoader.ReadConfig();
    }

    #region StandartSimulate
    public void StartGameSimulation()
    {

        GameObject.Find("StartPanel").SetActive(false);
        GameArena = ArenaCreator.ArenaLoadGenerator(ArenaPrefab, ConfigLoader.gameAreaWidth, ConfigLoader.gameAreaHeight);
        StartGenerate = true;
    }
    public void RestartGameSimulation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (!win && mustCheck)
        {
            CheckWin();
        }
        if (StartGenerate)
        {
            if (TimeSpawn >= ConfigLoader.unitSpawnDelay / 1000)
            {
                if (GeneratedBalls < ConfigLoader.numUnitsToSpawn)
                {
                    GenerateTeams();
                    GeneratedBalls++;
                }
                else
                {
                    StartGenerate = false;
                    mustCheck = true;
                }
                TimeSpawn = 0;
            }
            else
            {
                TimeSpawn += Time.deltaTime;
            }
        }
    }


    public void GenerateTeams()
    {

        if (GeneratedBalls % 2 == 0)
        {
            GameObject Ball = BallsGenerator.BaalsProps(GameArena, GetComponent<GameManager>(), "Blue");
            BlueTeam.Add(Ball);
            GameObject.Find("BlueTeam").GetComponent<Slider>().maxValue = BlueTeam.Count;
            GameObject.Find("BlueTeam").GetComponent<Slider>().value = BlueTeam.Count;

        }
        else
        {
            GameObject Ball = BallsGenerator.BaalsProps(GameArena, GetComponent<GameManager>(), "Red");
            RedTeam.Add(Ball);
            GameObject.Find("RedTeam").GetComponent<Slider>().maxValue = RedTeam.Count;
            GameObject.Find("RedTeam").GetComponent<Slider>().value = RedTeam.Count;

        }

    }


    public void DestroyBall(GameObject ball)
    {
        if (ball.tag == "Blue")
        {
            BlueTeam.Remove(ball);
            Destroy(ball);
        }
        if (ball.tag == "Red")
        {
            RedTeam.Remove(ball);
            Destroy(ball);
        }
        GameObject.Find("BlueTeam").GetComponent<Slider>().value = BlueTeam.Count;
        GameObject.Find("RedTeam").GetComponent<Slider>().value = RedTeam.Count;
    }

    public void CheckWin()
    {
        if (RedTeam.Count == 0)
        {
            GameObject.Find("Time").GetComponent<TimeSimulate>().stop = true;
            WinPanel.SetActive(true);
            WinPanel.transform.Find("WinText").GetComponent<Text>().text = "Победила Синяя команда за" + GameObject.Find("Time").GetComponent<Text>().text;
            win = true;
        }
        if (BlueTeam.Count == 0)
        {
            GameObject.Find("Time").GetComponent<TimeSimulate>().stop = true;
            WinPanel.SetActive(true);
            WinPanel.transform.Find("WinText").GetComponent<Text>().text = "Победила Красная команда за" + GameObject.Find("Time").GetComponent<Text>().text;
            win = true;
        }
    }
    #endregion

    #region LoadGame
    public void LoadCreator()
    {
        GameObject.Find("StartPanel").SetActive(false);
        if (PlayerPrefs.GetString("Save") != "")
        {
            JSONNode LoadSave = SimpleJSON.JSON.Parse(PlayerPrefs.GetString("Save"));
            GameArena = ArenaCreator.ArenaLoadGenerator(ArenaPrefab, int.Parse(LoadSave["gameAreaWidth"]), int.Parse(LoadSave["gameAreaHeight"]));
            for (int i = 0; i < LoadSave["RedPositionNow"].Count; i++)
            {
                Vector2 RedPositionNow = new Vector2(LoadSave["RedPositionNow"][i]["x"], LoadSave["RedPositionNow"][i]["y"]);
                Vector2 RedVectorsNow = new Vector2(LoadSave["RedVectorsNow"][i]["x"], LoadSave["RedVectorsNow"][i]["y"]);
                Vector2 RedScale = new Vector2(LoadSave["RedScale"][i]["x"], LoadSave["RedScale"][i]["y"]);
                float RedspeedS = float.Parse(LoadSave["Redspeed"][i]);
              GameObject _Ball =  BallsGenerator.BaalsLoadProps(GameArena, GetComponent<GameManager>(), "Red", RedPositionNow, RedScale, RedVectorsNow, RedspeedS);
                RedTeam.Add(_Ball);
                GameObject.Find("RedTeam").GetComponent<Slider>().maxValue = RedTeam.Count;
                GameObject.Find("RedTeam").GetComponent<Slider>().value = RedTeam.Count;
            }

            for (int i = 0; i < LoadSave["BluePositionNow"].Count; i++)
            {
                Vector2 RedPositionNow = new Vector2(LoadSave["BluePositionNow"][i]["x"], LoadSave["BluePositionNow"][i]["y"]);
                Vector2 RedVectorsNow = new Vector2(LoadSave["BlueVectorsNow"][i]["x"], LoadSave["BlueVectorsNow"][i]["y"]);
                Vector2 RedScale = new Vector2(LoadSave["BlueScale"][i]["x"], LoadSave["BlueScale"][i]["y"]);
                float BluespeedS = float.Parse(LoadSave["Bluespeed"][i]);
                GameObject _Ball = BallsGenerator.BaalsLoadProps(GameArena, GetComponent<GameManager>(), "Blue", RedPositionNow, RedScale, RedVectorsNow, BluespeedS);
                BlueTeam.Add(_Ball);
                GameObject.Find("BlueTeam").GetComponent<Slider>().maxValue = BlueTeam.Count;
                GameObject.Find("BlueTeam").GetComponent<Slider>().value = BlueTeam.Count;
            }

            GameObject.Find("Time").GetComponent<TimeSimulate>().time = LoadSave["TimeSimulate"];
            mustCheck = true;
        }
    }
}
    #endregion




