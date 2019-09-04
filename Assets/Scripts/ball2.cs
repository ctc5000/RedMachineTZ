using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball2 : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float speed;
    public Slider SpeedSlider;
    public GameObject Arena;
    public float StartSize;
    public float SpeedSuplier;
    public GameManager Gm;
    public GameObject camobject;
    // Use this for initialization
    void Start()
    {
        SpeedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        camobject = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
           SpeedSuplier = SpeedSlider.value;
            transform.Translate(Vector2.right * speed * SpeedSuplier * Time.deltaTime* moveX);
            transform.Translate(Vector2.up * speed* SpeedSuplier * Time.deltaTime* moveY);

        //  Camera cam = camobject.GetComponent<Camera>(); //Камера на основе которой будем определять вышел ли объект за ее границы
        // Vector3 point = cam.WorldToViewportPoint(transform.position); //Записываем положение объекта к границам камеры, X и Y это будут как раз верхние и нижние границы камеры
        /*   if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f)
           {
               transform.position = new Vector2(0, 0);
           }*/
        ConfigLoader.ReadConfig();


        if (transform.position.x < (-ConfigLoader.gameAreaWidth / 2) + 2f)
        {
            moveX = -moveX;
        }
        if (transform.position.x > (ConfigLoader.gameAreaWidth / 2)-2f)
        {
            moveX = -moveX;
        }
        if (transform.position.y < (-ConfigLoader.gameAreaHeight / 2) + 2f)
        {
            moveY = -moveY;
        }
        if (transform.position.y > (ConfigLoader.gameAreaHeight / 2) -2f)
        {
            moveY = -moveY;
        }

        if (transform.position.x < (-ConfigLoader.gameAreaWidth / 2) - 2f|| transform.position.x > (ConfigLoader.gameAreaWidth / 2) + 2f)
        {
            transform.position = new Vector2(0, 0);
        }
        if (transform.position.y < (-ConfigLoader.gameAreaHeight / 2) - 2f|| transform.position.y > (ConfigLoader.gameAreaHeight / 2) + 2f)
        {
           transform.position = new Vector2(0, 0);
        }
       



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.collider.tag != gameObject.tag)
            {

                if ((transform.localScale.x - StartSize / 10) <=  0.2f)
                {
                    Gm.DestroyBall(gameObject);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(transform.localScale.x -0.1f , transform.localScale.y-0.1f , 0);
                }
                moveX = -moveX;
                moveY = -moveY;
              
            }
            else
            {
                moveX = -moveX;
                moveY = -moveY;
            }
    }
       
    
}
