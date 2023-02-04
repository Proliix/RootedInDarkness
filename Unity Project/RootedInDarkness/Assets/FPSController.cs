using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravity = 9.81f;
 

    private CharacterController characterController;
    private Vector3 moveDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = (horizontal * transform.right + vertical * transform.forward).normalized;
        moveDirection *= walkSpeed;



        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
            
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
