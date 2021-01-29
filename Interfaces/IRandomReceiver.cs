using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomReceiver
{
    void SetRandomProvider(IRandomProvider provider);
}
