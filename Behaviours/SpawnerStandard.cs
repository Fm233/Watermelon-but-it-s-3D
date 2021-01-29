using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStandard : MonoBehaviour,
                               ISpawnReceiver,
                               IFruitFactoryReceiverStandard,
                               IScoreSender,
                               IResetable,
                               IAudioSender,
                               IParentReceiver,
                               IStateSender
{
    IFruitFactoryStandard factory;
    Action<int> scoreReceiver;
    Action<AudioClip> audioReceiver;
    IParentProvider parentProvider;
    Action<GameState> stateReceiver;


    public void AddAudioReceiver(Action<AudioClip> action)
    {
        audioReceiver += action;
    }

    public void AddScoreReceiver(Action<int> action)
    {
        scoreReceiver += action;
    }

    public void AddStateReceiver(Action<GameState> action)
    {
        stateReceiver += action;
    }

    public Action<Vector3, int> GetSpawnReceiver()
    {
        return Spawn;
    }

    public void ReceiveFactory(IFruitFactoryStandard factory)
    {
        this.factory = factory;
    }

    public void Reset()
    {
    }

    public void SetParentProvider(IParentProvider provider)
    {
        parentProvider = provider;
    }

    public void Spawn(Vector3 pos, int level)
    {
        int fruitLevel = level;
        GameObject fruitObject = factory.MakeFruit(new FruitStandardModel(fruitLevel));
        fruitObject.transform.position = pos;
        fruitObject.transform.parent = parentProvider.GetParent();
        if (fruitObject.TryGetComponent(out FruitStandard fruit))
        {
            fruit.AddSpawnReceiver(Spawn);
            fruit.AddScoreReceiver(scoreReceiver);
            fruit.AddAudioReceiver(audioReceiver);
            fruit.AddStateReceiver(stateReceiver);
        }
    }
}
