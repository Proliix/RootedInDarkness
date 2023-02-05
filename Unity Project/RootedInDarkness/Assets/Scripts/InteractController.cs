using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ViewModelType { Idle, Point, Interact, Grab, Key, Machete, Screwdriver, Fuck }
public class InteractController : MonoBehaviour
{
    public static InteractController Instance;
    [SerializeField] float interactLenght = 1000;
    [SerializeField] Sprite idle, point, interact, grab, key, machete, screwdriver, fuck;
    [SerializeField] ViewModelType currentViewModel;
    [SerializeField] ViewModelType currentIdle;
    [SerializeField] Image hudImage;

    RaycastHit hit;
    bool lookingAtInteractable;
    bool forceUpdateViewModel = false;
    bool canUpdateViewModel = true;
    IInteractable currentInterractable;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    void UpdateImage()
    {
        if (canUpdateViewModel)
        {

            forceUpdateViewModel = false;

            switch (currentViewModel)
            {
                case ViewModelType.Idle:
                    if (currentIdle != ViewModelType.Idle)
                    {
                        currentViewModel = currentIdle;
                        UpdateImage();
                    }
                    else
                        hudImage.sprite = idle;
                    break;
                case ViewModelType.Point:
                    hudImage.sprite = point;
                    break;
                case ViewModelType.Interact:
                    hudImage.sprite = interact;
                    break;
                case ViewModelType.Grab:
                    hudImage.sprite = grab;
                    StartCoroutine(WaitForViewModelUpdate());
                    break;
                case ViewModelType.Key:
                    hudImage.sprite = key;
                    break;
                case ViewModelType.Machete:
                    hudImage.sprite = machete;
                    break;
                case ViewModelType.Screwdriver:
                    hudImage.sprite = screwdriver;
                    break;
                case ViewModelType.Fuck:
                    hudImage.sprite = fuck;
                    break;
            }
        }
    }

    IEnumerator WaitForViewModelUpdate()
    {
        canUpdateViewModel = false;
        yield return new WaitForSeconds(0.25f);
        forceUpdateViewModel = true;
        canUpdateViewModel = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lookingAtInteractable)
        {
            currentInterractable = hit.collider.gameObject.GetComponent<IInteractable>();
            if (currentInterractable != null)
            {
                currentViewModel = ViewModelType.Grab;
                UpdateImage();
                currentInterractable.Interact();
            }
            else
            {
                Debug.LogError(hit.collider.gameObject.name + " does not have a interactable script", hit.collider.gameObject);

            }
        }
    }

    public void ChangeIdleState(ViewModelType type)
    {
        currentIdle = type;
    }

    public void ResetIdleState()
    {
        currentIdle = ViewModelType.Idle;
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (6) to get a bit mask
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactLenght, layerMask))
        {
            if (!lookingAtInteractable || forceUpdateViewModel)
            {
                currentViewModel = ViewModelType.Interact;
                UpdateImage();
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            lookingAtInteractable = true;
        }
        else
        {
            if (lookingAtInteractable || forceUpdateViewModel)
            {
                currentViewModel = ViewModelType.Idle;
                UpdateImage();
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactLenght, Color.white);
            lookingAtInteractable = false;
        }
    }
}


