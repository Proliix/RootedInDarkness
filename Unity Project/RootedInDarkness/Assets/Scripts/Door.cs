using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] int keyNum;
    [SerializeField] bool needKey = true;
    [SerializeField] bool canOpen = false;

    InventoryManager invManager;

    public void Interact()
    {
        if (needKey)
        {
            canOpen = invManager.FindKey(keyNum);
        }

        if (canOpen)
            OpenDoor();
    }

    private void OpenDoor()
    {
        Destroy(gameObject);    
    }

    // Start is called before the first frame update
    void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
