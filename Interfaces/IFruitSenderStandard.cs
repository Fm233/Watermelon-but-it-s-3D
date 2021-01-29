using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IFruitSenderStandard
{
    void AddFruitReceiver(Action<FruitStandardModel> action);
}
