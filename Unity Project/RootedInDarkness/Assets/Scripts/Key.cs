using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public int KeyNum;

    InventoryManager invManager;
    private void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
    }
    public void Interact()
    {
        Debug.LogError(KeyNum);
        invManager.AddKey(KeyNum);
        Destroy(gameObject);
    }
}
