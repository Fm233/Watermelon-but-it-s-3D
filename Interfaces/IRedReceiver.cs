using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IRedReceiver
{
    Action<bool> GetRedReceiver();
}
