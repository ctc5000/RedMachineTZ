using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSimulate : MonoBehaviour
{
    public bool stop;
    public float time;
    void Update()
    {
        if(!stop)
        {
            time += Time.fixedDeltaTime;
        GetComponent<Text>().text = time.ToString("0")+" sec";
        }
    }
}
