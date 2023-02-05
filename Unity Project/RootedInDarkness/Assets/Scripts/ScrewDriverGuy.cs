using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriverGuy : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject hand;
    InventoryManager invManager;
    public void Interact()
    {
        if (invManager.CheckMachete())
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
            gameObject.layer = LayerIgnoreRaycast;
            InteractController.Instance.ChangeIdleState(ViewModelType.Screwdriver);
            hand.SetActive(false);
            invManager.AddScrewdriver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();
    }

}
