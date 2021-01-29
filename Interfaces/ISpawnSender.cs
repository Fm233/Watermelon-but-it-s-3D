using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISpawnSender
{
    void AddSpawnReceiver(Action<Vector3, int> action);
}
