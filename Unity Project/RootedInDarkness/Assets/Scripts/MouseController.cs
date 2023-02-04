using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float mouseSensitivity = 100.0f;
    private float rotY;
    public Camera mainCamera;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -90, 90);

        transform.localEulerAngles = new Vector3(-0.0f, rotX, 0.0f);
        mainCamera.transform.localEulerAngles = new Vector3(-rotY, 0.0f, 0.0f);
    }
}
