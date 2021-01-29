using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTrigger : IStateSender, IStateReceiver, IResetable
{
    Action<GameState> stateReceiver;
    GameState state;

    public void AddStateReceiver(Action<GameState> action)
    {
        stateReceiver += action;
    }

    public Action<GameState> GetStateReceiver()
    {
        return SetState;
    }

    public void SetState(GameState inState)
    {
        state = inState;
        stateReceiver(inState);
    }

    public void Reset()
    {
        SetState(GameState.PLAYING);
    }
}
