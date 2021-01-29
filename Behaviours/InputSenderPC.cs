using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class InputSenderPC : InputSender, IAudioSender
{
    public AudioClip clip;

    Action<AudioClip> audioReceiver;
    Action<Vector3, int> spawnAction;
    IRandomProvider random;

    public void AddAudioReceiver(Action<AudioClip> action)
    {
        audioReceiver += action;
    }

    public override void AddSpawnReceiver(Action<Vector3, int> action)
    {
        spawnAction += action;
    }

    public override void Reset()
    {
    }

    public override void SetRandomProvider(IRandomProvider provider)
    {
        random = provider;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector3 pos = hit.point;
                pos.y = Const.FRUIT_SPAWN_Y;
                spawnAction(pos, random.Get());
                random.Randomize(5);
                audioReceiver(clip);
            }
        }
    }
}
