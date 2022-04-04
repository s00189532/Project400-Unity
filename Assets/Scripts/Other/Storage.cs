using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    float StoredIron = 0;
    float StoredWood = 0;

    public GameObject StoragePosition;

    public void StoreIron(float amount)
    {
        StoredIron += amount;
    }

    public void TakeIron(float amount)
    {
        if (StoredIron >= amount)
            StoredIron -= amount;
    }

    public void StoreWood(float amount)
    {
        StoredWood += amount;
    }

    public void TakeWood(float amount)
    {
        if (StoredWood >= amount)
            StoredWood -= amount;
    }
}
