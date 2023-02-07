using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameobjectToggler))]
public class PowerSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] int keyNum = 1337;
    [SerializeField] AudioClip switchSound;
    bool interactable = false;
    Animator anim;
    BoxCollider col;
    GameobjectToggler toggler;
    InventoryManager inv;
    public void Interact()
    {
        if (interactable)
        {
            inv.AddKey(keyNum);
            SoundManager.Instance.PlayAudio(switchSound);
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            gameObject.layer = LayerIgnoreRaycast;
            anim.SetTrigger("Switch");
            StartCoroutine(WaitForScarySound());
            toggler.UpdateObjects();
        }
    }

    IEnumerator WaitForScarySound()
    {
        yield return new WaitForSeconds(1);
        SoundManager.Instance.PlayRandomSoundEffect();
    }

    public void ChangeInteractable(bool value)
    {
        interactable = value;
    }

    private void Start()
    {
        inv = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
        col = gameObject.GetComponent<BoxCollider>();
        anim = gameObject.GetComponent<Animator>();
        toggler = gameObject.GetComponent<GameobjectToggler>();
    }
}
