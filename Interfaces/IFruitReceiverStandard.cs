using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IFruitReceiverStandard
{
    Action<FruitStandardModel> GetFruitReceiver();
}
