using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalCabinet : MonoBehaviour, IInteractable
{
    //[SerializeField] AudioClip openSound;
    [SerializeField] PowerSwitch powerSwitch;
    Animator anim;
    InventoryManager inv;
    public void Interact()
    {
        if (inv.CheckScrewdriver())
        {
            anim.SetTrigger("Open");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            gameObject.layer = LayerIgnoreRaycast;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            powerSwitch.ChangeInteractable(true);
            InteractController.Instance.ResetIdleState();
        }
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        inv = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
    }
}
