using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreReceiver
{
    Action<int> GetScoreReceiver();
}
