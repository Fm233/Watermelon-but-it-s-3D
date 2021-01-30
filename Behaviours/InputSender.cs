using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSender : MonoBehaviour, ISpawnSender, IResetable, IRandomReceiver
{
    public AudioClip clip;

    Action<AudioClip> audioReceiver;
    Action<Vector3, int> spawnAction;
    IRandomProvider random;

    public void AddAudioReceiver(Action<AudioClip> action)
    {
        audioReceiver += action;
    }

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
        random.Randomize(5);
        audioReceiver(clip);
    }
}
