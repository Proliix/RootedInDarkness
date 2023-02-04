using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAnimation : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip[] soundEffects;
    Animator anim;

    public void Interact()
    {
        anim.SetTrigger("Interact");
        if (soundEffects.Length > 0)
        {
            int r = Random.Range(0, soundEffects.Length);
            SoundManager.Instance.PlayAudio(soundEffects[r]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

}
