using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    float yaw;  //left/right
    float pitch;    //up/down

    public Transform playerCamera;

    void Start()
    {
        playerCamera = (GetComponentInChildren<Camera>()).transform;
    }

    // Update is called once per frame
    void Update()
    {
        //---move player---
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;

        Vector3 moveAmount = moveInput.x * (new Vector3(playerCamera.right.x, 0, playerCamera.right.z)) + moveInput.y * (new Vector3(playerCamera.forward.x, 0, playerCamera.forward.z));   //move to the right as specified by input, and also forward/backward as specified...
        moveAmount = moveAmount * 10f * Time.deltaTime;

        transform.Translate(moveAmount, Space.Self);


        //---mouse input---
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -45f, 90f);

        playerCamera.transform.localEulerAngles = new Vector3(pitch, yaw, 0);
    }
}
