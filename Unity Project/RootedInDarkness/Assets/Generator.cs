using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public GameObject button1;
    public GameObject button2;
    public GameObject lightObj;
    [SerializeField] int keyNum;
    [SerializeField] bool usesObjectToggler;

    GameobjectToggler toggler;
    InventoryManager invManager;
    Animator soundAnim;
    Animator lightAnim;
    public void Interact()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerIgnoreRaycast;
        ShutDownGenerator();
    }

    private void ShutDownGenerator()
    {

        //audioSource.Stop();
        button1.SetActive(false);
        button2.SetActive(false);
        invManager.AddKey(keyNum);
        soundAnim.SetTrigger("StopSound");
        lightAnim.SetTrigger("StartFade");

        if (usesObjectToggler)
            toggler.UpdateObjects();
    }

    private void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
        soundAnim = audioSource.gameObject.GetComponent<Animator>();
        lightAnim = lightObj.GetComponent<Animator>();
        if (usesObjectToggler)
            toggler = gameObject.GetComponent<GameobjectToggler>();
    }

}
