using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreSender
{
    void AddScoreReceiver(Action<int> action);
}
