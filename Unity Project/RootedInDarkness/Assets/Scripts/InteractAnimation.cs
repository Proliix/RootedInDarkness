using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAnimation : MonoBehaviour, IInteractable
{

    Animator anim;

    public void Interact()
    {
        anim.SetTrigger("Interact");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
