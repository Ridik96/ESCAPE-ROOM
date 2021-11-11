using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    private float xRotation = 0f;
    private float yStartPosition = 1.18f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseSens = mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X")*mouseSens;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.localPosition = Vector3.zero ;
        }
        else
        {
            transform.localPosition = new Vector3(0f, yStartPosition, 0f);
        }
       
    }
}
