using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> RedTeam;
    public List<GameObject> BlueTeam;
    public GameObject ArenaPrefab;
    public GameObject GameArena;
    public ArenaCreator Creator;
    public GameObject WinPanel;
    public bool StartGenerate ;
    public int maxGenerated;
    int GeneratedBalls;
    public float TimeCreate;
    float TimeSpawn;
    bool win;
    bool mustCheck;
    public GameObject camobject;

    // Start is called before the first frame update
    void Start()
    {
        ConfigLoader.ReadConfig();
        camobject = GameObject.Find("Main Camera");
        if (ConfigLoader.gameAreaHeight > ConfigLoader.gameAreaWidth) camobject.GetComponent<Camera>().orthographicSize = ConfigLoader.gameAreaHeight + 20;
        else camobject.GetComponent<Camera>().orthographicSize = ConfigLoader.gameAreaWidth + 20;
    }



    public void StartGameSimulation()
    {
        GameObject.Find("StartPanel").SetActive(false);
        GameArena= ArenaCreator.ArenaGenerator(ArenaPrefab);
        StartGenerate = true;
    }
    public void RestartGameSimulation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (!win&&mustCheck)
        {
            CheckWin();
        }
        if (StartGenerate)
        {
            if (TimeSpawn >= TimeCreate)
            {
                if (GeneratedBalls < maxGenerated)
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
            GameObject Ball = BallsGenerator.BaalsProps(GameArena, "Blue", Color.blue, GetComponent<GameManager>());
            BlueTeam.Add(Ball);
            GameObject.Find("BlueTeam").GetComponent<Slider>().maxValue = BlueTeam.Count;
            GameObject.Find("BlueTeam").GetComponent<Slider>().value = BlueTeam.Count;
           
        }
        else
        {
            GameObject Ball = BallsGenerator.BaalsProps(GameArena, "Red", Color.red, GetComponent<GameManager>());
            RedTeam.Add(Ball);
            GameObject.Find("RedTeam").GetComponent<Slider>().value = RedTeam.Count;
            GameObject.Find("RedTeam").GetComponent<Slider>().maxValue = RedTeam.Count;
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

}
