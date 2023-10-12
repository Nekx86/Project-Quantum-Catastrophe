using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float MouseSensitivity = 2.0f;
    private float VerticalRotation = 0;
    private float UpDownRange = 60.0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
    private void Update()
    {
        float rotX = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.Rotate(0, rotX, 0);
        VerticalRotation -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        VerticalRotation = Mathf.Clamp(VerticalRotation, -UpDownRange, UpDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(VerticalRotation, 0, 0);
    }
}  
