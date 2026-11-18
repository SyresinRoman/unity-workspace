using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; 

    private float _yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
   
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

   
        _yRotation -= mouseY;
  
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

      
        transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);

      
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
