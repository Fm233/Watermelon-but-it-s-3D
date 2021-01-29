using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISpawnReceiver
{
    Action<Vector3, int> GetSpawnReceiver();
}
