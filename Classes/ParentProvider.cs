using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentProvider : IParentProvider, IResetable
{
    Transform parent;
    int num = 0;

    public ParentProvider()
    {
        Reset();
    }

    public Transform GetParent()
    {
        return parent;
    }

    public void Reset()
    {
        GameObject.Destroy(parent?.gameObject);
        GameObject go = new GameObject();
        go.name = num.ToString();
        num++;
        parent = go.transform;
    }
}
