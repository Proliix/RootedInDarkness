using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip openClip;
    [SerializeField] AudioClip[] lockedClips;
    [SerializeField] int keyNum;
    [SerializeField] bool needKey = true;
    [SerializeField] bool canOpen = false;

    InventoryManager invManager;
    Animator anim;

    public void Interact()
    {
        if (needKey)
        {
            canOpen = invManager.FindKey(keyNum);
        }

        if (canOpen)
            OpenDoor();
        else if (lockedClips.Length > 0)
        {
            int r = Random.Range(0, lockedClips.Length);
            SoundManager.Instance.PlayAudio(lockedClips[r]);
            anim.SetTrigger("Locked");
        }
    }

    private void OpenDoor()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerIgnoreRaycast;
        anim.SetTrigger("Open");
    }

    // Start is called before the first frame update
    void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
