using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerCamRotation : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform playerOrientation;

    float xRot;
    float yRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //up and down rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //left and right rotation
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        playerOrientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
