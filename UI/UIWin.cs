using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stopwatch = System.Diagnostics.Stopwatch;
using System;

public class UIWin : MonoBehaviour
{
    public Image image;
    public Text text;
    Stopwatch timer = new Stopwatch();

    private void OnEnable()
    {
        timer.Restart();
    }

    void Update()
    {
        float sec = timer.ElapsedMilliseconds / 1000f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, F1(sec) * 0.5f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, F2(sec));
        if (sec > 3.5f)
        {
            gameObject.SetActive(false);
        }
    }

    float F1(float sec)
    {
        if (sec < 0.2f)
        {
            return sec * 5f;
        }
        if (sec < 2.8f)
        {
            return 1f;
        }
        if (sec < 3f)
        {
            return (3 - sec) * 5f;
        }
        return 0f;
    }

    float F2(float sec)
    {
        if (sec < 0.5f)
        {
            return sec * 2f;
        }
        if (sec < 2.5f)
        {
            return 1f;
        }
        if (sec < 3f)
        {
            return (3 - sec) * 2f;
        }
        return 0f;
    }
}
