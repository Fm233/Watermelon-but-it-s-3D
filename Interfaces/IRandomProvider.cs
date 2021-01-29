using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomProvider
{
    void Randomize(int exclusiveUpperBound);
    int Get();
}
