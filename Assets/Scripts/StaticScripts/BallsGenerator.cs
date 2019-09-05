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
        NewBall.transform.position = new Vector2(Random.Range(-ConfigLoader.gameAreaWidth/2+ 5, ConfigLoader.gameAreaWidth/2 - 5), Random.Range(-ConfigLoader.gameAreaHeight/2 + 5, ConfigLoader.gameAreaHeight/2-5));
        NewBall.GetComponent<ball2>().moveX = Random.RandomRange(-1.0f, 1.0f);
        NewBall.GetComponent<ball2>().moveY = Random.RandomRange(-1.0f,1.0f);
        NewBall.GetComponent<ball2>().speed = Random.RandomRange(ConfigLoader.minUnitSpeed, ConfigLoader.maxUnitSpeed);
        NewBall.GetComponent<ball2>().Gm = Gm;
        NewBall.GetComponent<ball2>().Arena = Arena;
        float RadiusBall = Random.Range(ConfigLoader.minUnitRadius, ConfigLoader.maxUnitRadius);
        NewBall.transform.localScale = new Vector3(RadiusBall, RadiusBall, 0);
        return NewBall;
    }

    public static GameObject BaalsLoadProps(GameObject Arena, GameManager Gm, string Prefab, Vector2 Position, Vector2 Scale, Vector2 Vectors, float Speed)
    {
        GameObject NewBall = Instantiate(Resources.Load<GameObject>(Prefab));
        NewBall.transform.position = Position;
        NewBall.GetComponent<ball2>().moveX = Vectors.x;
        NewBall.GetComponent<ball2>().moveY = Vectors.y;
        NewBall.GetComponent<ball2>().speed = Speed;
        NewBall.GetComponent<ball2>().Gm = Gm;
        NewBall.GetComponent<ball2>().Arena = Arena;
        NewBall.transform.localScale = Scale;
        return NewBall;
    }

}
