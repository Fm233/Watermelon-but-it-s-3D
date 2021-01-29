using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreSenderDynamic
{
    void AddScoreReceiver(Action<int> action);
}
