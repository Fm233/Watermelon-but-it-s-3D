using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FruitStandard : MonoBehaviour,
                                      IFruitReceiverStandard,
                                      IFruitGetterStandard,
                                      IFruitBreakable,
                                      IScoreSenderDynamic,
                                      ISpawnSender,
                                      IStateSender,
                                      IFruitAgeable,
                                      IHideable,
                                      IColorable,
                                      IAudioSender
{
    public abstract void AddAudioReceiver(Action<AudioClip> action);
    public abstract void AddScoreReceiver(Action<int> action);
    public abstract void AddSpawnReceiver(Action<Vector3, int> action);
    public abstract void AddStateReceiver(Action<GameState> action);
    public abstract void Break();
    public abstract Color GetColor();
    public abstract FruitStandardModel GetFruit();
    public abstract Action<FruitStandardModel> GetFruitReceiver();
    public abstract float GetTime();
    public abstract void Hide(bool state);
}
