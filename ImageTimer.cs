using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    public Image img;
    private float currentTime;
    public float maxTime;
    public bool tick;

    void Start()
    {
        img = GetComponent<Image>();
        currentTime = maxTime;
    }


    void Update()
    {
        tick = false;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            tick = true;
            currentTime = maxTime;
        }
        img.fillAmount = currentTime / maxTime;
    }
}
