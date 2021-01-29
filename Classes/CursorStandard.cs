using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorStandard : ISpawnReceiver, IFruitFactoryReceiverStandard, IResetable
{
    IFruitFactoryStandard factory;
    int currentLevel = -1;
    GameObject cursor;

    public Action<Vector3, int> GetSpawnReceiver()
    {
        return SetCursor;
    }

    public void ReceiveFactory(IFruitFactoryStandard inFactory)
    {
        factory = inFactory;
    }

    public void Reset()
    {
    }

    public void SetCursor(Vector3 pos, int level)
    {
        if (level != currentLevel)
        {
            currentLevel = level;
            cursor?.SetActive(false);
            cursor = InstantiateCursor(level);
        }
        cursor.transform.position = pos;
    }

    GameObject InstantiateCursor(int level)
    {
        // Generate fruit
        FruitStandard fruit = factory.MakeFruit(new FruitStandardModel(level)).GetComponent<FruitStandard>();
        fruit.Hide(true);
        Color color = fruit.GetColor();

        // Add line
        GameObject line = new GameObject();
        LineRenderer lr = line.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.startColor = color;
        lr.endColor = color;
        lr.useWorldSpace = false;
        lr.positionCount = 2;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.down * 30f);
        line.transform.parent = fruit.transform;

        return fruit.gameObject;
    }
}
