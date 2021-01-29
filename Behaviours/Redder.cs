using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Stopwatch = System.Diagnostics.Stopwatch;

public class Redder : MonoBehaviour, IRedReceiver, IResetable
{
    public PostProcessVolume volume;
    public GameObject redPlane;
    float redness = 0;
    Stopwatch blinkTimer = new Stopwatch();
    bool blinking = false;

    public Action<bool> GetRedReceiver()
    {
        return ReceiveRed;
    }

    void ReceiveRed(bool add)
    {
        redness += add ? 0.2f : -0.2f;
        volume.weight = redness;
    }

    private void Update()
    {
        if (redness > 0.1f && !blinking)
        {
            blinking = true;
            blinkTimer.Restart();
            redPlane.SetActive(true);
        }
        if (redness < 0.1f && blinking)
        {
            blinking = false;
            blinkTimer.Stop();
            redPlane.SetActive(false);
        }
        if (blinking)
        {
            if (blinkTimer.ElapsedMilliseconds > Const.BLINK_INTERVAL * 1000)
            {
                blinkTimer.Restart();
                redPlane.SetActive(!redPlane.activeSelf);
            }
        }
    }

    public void Reset()
    {
        redness = 0;
        blinking = false;
        blinkTimer.Stop();
        redPlane.SetActive(false);
        volume.weight = 0f;
    }
}
