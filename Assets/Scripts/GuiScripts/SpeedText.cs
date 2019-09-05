using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    public Slider SpeedSlider;

    void Start()
    {
        SpeedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = SpeedSlider.value.ToString();
    }
}
