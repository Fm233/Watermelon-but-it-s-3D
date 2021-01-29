using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFactoryStandard : MonoBehaviour, IFruitFactoryStandard, IResetable
{
    public GameObject[] fruitPrefabs;

    public GameObject MakeFruit(FruitStandardModel fruit)
    {
        if (fruit.level < fruitPrefabs.Length)
        {
            GameObject fruitObject = Instantiate(fruitPrefabs[fruit.level]);
            if (fruitObject.TryGetComponent(out FruitStandard fruitComp))
            {
                fruitComp.GetFruitReceiver()(fruit);
            }
            return fruitObject;
        }
        return null;
    }

    public void Reset()
    {
    }
}
