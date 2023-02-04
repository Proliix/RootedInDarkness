using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public int KeyNum;

    public void Interact()
    {
        Debug.LogError(KeyNum);
        Destroy(gameObject);
    }
}
