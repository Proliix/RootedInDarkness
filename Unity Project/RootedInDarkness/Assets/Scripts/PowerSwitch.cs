using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameobjectToggler))]
public class PowerSwitch : MonoBehaviour, IInteractable
{
    bool interactable = false;
    Animator anim;
    BoxCollider col;
    GameobjectToggler toggler;
    public void Interact()
    {
        if (interactable)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            gameObject.layer = LayerIgnoreRaycast;
            anim.SetTrigger("Switch");
            toggler.UpdateObjects();
        }
    }

    public void ChangeInteractable(bool value)
    {
        interactable = value;
    }

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.GetComponent<Animator>();
        toggler = gameObject.GetComponent<GameobjectToggler>();
    }
}
