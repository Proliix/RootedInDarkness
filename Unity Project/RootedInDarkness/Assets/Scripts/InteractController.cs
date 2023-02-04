using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewModelType { Idle,Point,Interact,Grab,Punch,Key,Machete,Screwdriver,Fuck}
public class InteractController : MonoBehaviour
{
    [SerializeField] float interactLenght = 1000;

    RaycastHit hit;
    bool lookingAtInteractable;
    IInteractable currentInterractable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lookingAtInteractable)
        {
            currentInterractable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (currentInterractable != null)
            {
                currentInterractable.Interact();
            }
            else
            {
                Debug.LogError(hit.collider.gameObject.name + " does not have a interactable script", hit.collider.gameObject);

            }
        }
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (6) to get a bit mask
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactLenght, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            lookingAtInteractable = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactLenght, Color.white);
            lookingAtInteractable = false;
        }
    }
}


