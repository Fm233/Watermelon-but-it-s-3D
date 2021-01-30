using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSenderConstant : MonoBehaviour, ISpawnSender, IResetable, IRandomReceiver
{
    Action<Vector3, int> spawnAction;
    IRandomProvider random;

    public void AddSpawnReceiver(Action<Vector3, int> action)
    {
        spawnAction += action;
    }

    public void Reset()
    {
    }

    public void SetRandomProvider(IRandomProvider provider)
    {
        random = provider;
    }

    public void Send(Vector3 pos)
    {
        if (UI.on) return;
        spawnAction(pos, random.Get());
    }
}
