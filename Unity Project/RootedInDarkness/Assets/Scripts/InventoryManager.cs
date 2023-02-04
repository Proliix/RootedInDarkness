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

    public int FindKey(int keyNum)
    {
        int returnValue = -1;

        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i] == keyNum)
            {
                returnValue = keyNum;
                break;
            }
        }
        return returnValue;
    }

}
