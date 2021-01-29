using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IRedSender
{
    void AddRedReceiver(Action<bool> action);
}
