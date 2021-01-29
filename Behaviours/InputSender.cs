using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSender : MonoBehaviour, ISpawnSender, IResetable, IRandomReceiver
{
    public abstract void AddSpawnReceiver(Action<Vector3, int> action);
    public abstract void Reset();
    public abstract void SetRandomProvider(IRandomProvider provider);
}
