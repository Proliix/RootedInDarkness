using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float gravity = -1f;
  
 

    private CharacterController characterController;
    private MouseController mouseController;
    private Vector3 moveDirection;
    

    private void Start()
    {
        mouseController = GetComponent<MouseController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = (horizontal * transform.right + vertical * transform.forward).normalized;
        moveDirection *= walkSpeed;




        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;

        }


        moveDirection.y -= gravity;

        characterController.Move(moveDirection * Time.deltaTime);


    }


}
