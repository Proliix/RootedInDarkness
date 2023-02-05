using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<int> keys;
    bool hasMachete = false;
    bool hasScrewdriver = false;

    private void Start()
    {
        keys = new List<int>();
    }
    public void AddKey(int keyNum)
    {
        keys.Add(keyNum);
    }

    public void AddMachete()
    {
        hasMachete = true;
    }

    public bool CheckMachete()
    {
        return hasMachete;
    }

    public void AddScrewdriver()
    {
        hasScrewdriver = true;
    }

    public bool CheckScrewdriver()
    {
        return hasScrewdriver;
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
