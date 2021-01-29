using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IStateSender
{
    void AddStateReceiver(Action<GameState> action);
}
