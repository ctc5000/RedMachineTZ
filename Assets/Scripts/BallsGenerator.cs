using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{
    public GameObject BallPrefab;
    public GameObject Arena;
    public static GameObject BaalsProps(GameObject Arena, string tag, Color Team, GameManager Gm)
    {
        GameObject NewBall = Instantiate(Resources.Load<GameObject>("Ball"));
        Vector2 ArenaSize = Arena.transform.localScale;
        NewBall.transform.position = new Vector2(Random.Range(-ArenaSize.x / 2, ArenaSize.x / 2), Random.Range(-ArenaSize.y / 2, ArenaSize.y/2));
        NewBall.transform.parent = Arena.transform;
        NewBall.GetComponent<ball>().moveX = Random.RandomRange(-1.0f, 1.0f);
        NewBall.GetComponent<ball>().moveY = Random.RandomRange(-1.0f,1.0f);
        NewBall.GetComponent<ball>().speed = Random.RandomRange(ConfigLoader.minUnitSpeed, ConfigLoader.maxUnitSpeed);
        NewBall.GetComponent<ball>().Gm = Gm;
        NewBall.GetComponent<ball>().Arena = Arena;
        // изменение размера относительно арены
        float RadiusBall = Random.Range(ConfigLoader.minUnitRadius, ConfigLoader.maxUnitRadius);
        NewBall.transform.localScale = new Vector3(RadiusBall, RadiusBall, 0);
        NewBall.tag = tag;
        NewBall.GetComponent<SpriteRenderer>().color = Team;
        //NewBall.transform.parent = null;
        if (NewBall.transform.localScale.y > NewBall.transform.localScale.x)
        {
            NewBall.transform.localScale = new Vector3(NewBall.transform.localScale.y, NewBall.transform.localScale.y, 0);
            NewBall.GetComponent<ball>().StartSize = NewBall.transform.localScale.y;
        }
        else {
            NewBall.transform.localScale = new Vector3(NewBall.transform.localScale.x, NewBall.transform.localScale.x, 0);
            NewBall.GetComponent<ball>().StartSize = NewBall.transform.localScale.x;
        }
        return NewBall;
    }
  
}
