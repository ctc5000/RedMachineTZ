using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public float speed = 200;
    public Vector2 CurrientDir;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    //Vertical hit factor
    float hitFactor(Vector2 ballPos, Vector2 racketPos,float WallHeight)
    {
        return (ballPos.y - racketPos.y) / WallHeight;
    }
    //Horizontal hit factor
    float hitFactorHor(Vector2 ballPos, Vector2 WallPos, float WallWhidth)
    {
        return (ballPos.x + WallPos.x) / WallWhidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.name == "BorderVerticalRight")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            print(col.transform.position);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "BorderVerticalLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "BorderHorizon")
        {
            // Calculate hit Factor
            float x = hitFactorHor(transform.position, col.transform.position,  col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, -x).normalized;
            print(dir);
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }


      /*  if (col.gameObject.name == "Ball")
        {
            // Calculate hit Factor
            float x = hitFactorHor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, -x).normalized;
            print(dir);
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }*/

    }

}
