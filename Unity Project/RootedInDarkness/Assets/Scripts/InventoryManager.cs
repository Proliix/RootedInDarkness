using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<int> keys;

    private void Start()
    {
        keys = new List<int>();
    }
    public void AddKey(int keyNum)
    {
        keys.Add(keyNum);
    }

    public bool FindKey(int keyNum)
    {
        bool returnValue = false;

        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == keyNum)
            {
                returnValue = true;
                break;
            }
        }
        return returnValue;
    }

    
}
