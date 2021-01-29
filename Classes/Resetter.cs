using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : IResetter
{
    List<IResetable> resetables = new List<IResetable>();

    public void AddResetable(IResetable resetable)
    {
        resetables.Add(resetable);
    }

    public void ResetAll()
    {
        foreach (IResetable resetable in resetables)
        {
            resetable.Reset();
        }
    }
}
