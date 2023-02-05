using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public GameObject button1;
    public GameObject button2;

    InventoryManager invManager;

    private void Start()
    {
        invManager = GameObject.Find("GameController").GetComponent<InventoryManager>();
    }

    public void Interact()
    {
       
        ShutDownGenerator();

        
    }

    private void ShutDownGenerator()
    {

        audioSource.Stop();
        button1.SetActive(false);
        button2.SetActive(false);
    }

}
