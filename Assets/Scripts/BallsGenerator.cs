using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGenerator : MonoBehaviour
{
    public GameObject BallPrefab;
    public GameObject Arena;
    public static GameObject BaalsProps(GameObject Arena, GameManager Gm, string Prefab)
    {
        GameObject NewBall = Instantiate(Resources.Load<GameObject>(Prefab));
        NewBall.transform.position = new Vector2(Random.Range(-ConfigLoader.gameAreaWidth/2+ 2, ConfigLoader.gameAreaWidth/2 - 2), Random.Range((-ConfigLoader.gameAreaHeight/2) + 2, (ConfigLoader.gameAreaHeight/2)/-2));
        //NewBall.transform.parent = Arena.transform;
        NewBall.GetComponent<ball2>().moveX = Random.RandomRange(-1.0f, 1.0f);
        NewBall.GetComponent<ball2>().moveY = Random.RandomRange(-1.0f,1.0f);
        NewBall.GetComponent<ball2>().speed = Random.RandomRange(ConfigLoader.minUnitSpeed, ConfigLoader.maxUnitSpeed);
        NewBall.GetComponent<ball2>().Gm = Gm;
        NewBall.GetComponent<ball2>().Arena = Arena;
        // изменение размера относительно арены
        float RadiusBall = Random.Range(ConfigLoader.minUnitRadius, ConfigLoader.maxUnitRadius);
        NewBall.transform.localScale = new Vector3(RadiusBall, RadiusBall, 0);
        if (NewBall.transform.localScale.y > NewBall.transform.localScale.x)
        {
            NewBall.transform.localScale = new Vector3(NewBall.transform.localScale.y, NewBall.transform.localScale.y, 0);
            NewBall.GetComponent<ball2>().StartSize = NewBall.transform.localScale.y;
        }
        else {
            NewBall.transform.localScale = new Vector3(NewBall.transform.localScale.x, NewBall.transform.localScale.x, 0);
            NewBall.GetComponent<ball2>().StartSize = NewBall.transform.localScale.x;
        }
        return NewBall;
    }
  
}
