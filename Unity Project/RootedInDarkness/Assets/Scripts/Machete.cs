using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machete : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClip clip;

    InventoryManager invManager;
    private void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
    }
    public void Interact()
    {
        invManager.AddMachete();
        InteractController.Instance.ChangeIdleState(ViewModelType.Machete);

        if (clip != null)
            SoundManager.Instance.PlayAudio(clip);

        Destroy(gameObject);
    }
}
