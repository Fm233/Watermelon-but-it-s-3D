using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProviderTest : IRandomProvider, IResetable
{
    int num = 0;

    public int Get()
    {
        return 8;
    }

    public void Randomize(int exclusiveUpperBound)
    {
        num = Random.Range(0, exclusiveUpperBound);
    }

    public void Reset()
    {
        num = 0;
    }
}