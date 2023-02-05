using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectToggler : MonoBehaviour
{
    [SerializeField] GameObject[] disableObjs;
    [SerializeField] GameObject[] enableObjs;

    private void Start()
    {
        if (disableObjs.Length > 0)
        {
            for (int i = 0; i < disableObjs.Length; i++)
            {
                disableObjs[i].SetActive(true);
            }
        }

        if (enableObjs.Length > 0)
        {

            for (int i = 0; i < enableObjs.Length; i++)
            {
                enableObjs[i].SetActive(false);
            }
        }
    }

    public void UpdateObjects()
    {
        if (disableObjs.Length > 0)
        {
            for (int i = 0; i < disableObjs.Length; i++)
            {
                disableObjs[i].SetActive(false);
            }
        }
        if (enableObjs.Length > 0)
        {
            for (int i = 0; i < enableObjs.Length; i++)
            {
                enableObjs[i].SetActive(true);
            }
        }
    }
}
