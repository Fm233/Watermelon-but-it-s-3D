using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParentReceiver
{
    void SetParentProvider(IParentProvider provider);
}
