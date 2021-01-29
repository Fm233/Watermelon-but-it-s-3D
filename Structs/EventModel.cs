using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct EventModel
{
    public float start;
    public float end;
    public Action<float> action;
    public bool finished;

    public EventModel(float start, float end, Action<float> action)
    {
        this.start = start;
        this.end = end;
        this.action = action;
        finished = false;
        if (start == end)
        {
            throw new Exception("Duration is 0!");
        }
    }

    public float GetProgress(float time)
    {
        return (time - start) / (end - start);
    }
}
