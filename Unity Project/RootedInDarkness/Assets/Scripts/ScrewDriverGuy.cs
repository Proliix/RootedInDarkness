using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriverGuy : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject hand;
    [SerializeField] bool hasObjToggler = false;

    GameobjectToggler toggler;
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

            if (hasObjToggler)
                toggler.UpdateObjects();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        invManager = GameObject.FindWithTag("GameController").GetComponent<InventoryManager>();

        if (hasObjToggler)
            toggler = gameObject.GetComponent<GameobjectToggler>();
    }

}
