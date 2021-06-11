using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = -12f;
    float velocityY;

    public float mouseSensitivity = 5f;
    float yaw;  //left/right
    float pitch;    //up/down

    Transform camera;

    CharacterController playerBodyController;

    // Start is called before the first frame update
    void Start()
    {
        camera = (GetComponentInChildren<Camera>()).transform;
        playerBodyController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //---move player---
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;

        float moveSpeed = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 22f;
        else
            moveSpeed = 13f;

        Vector3 moveAmount = moveInput.x * (new Vector3(camera.right.x, 0, camera.right.z)) + moveInput.y * camera.forward;   //move to the right as specified by input, and also forward/backward as specified...
        moveAmount = moveAmount * moveSpeed * Time.deltaTime;

        velocityY += gravity * Time.deltaTime;
        moveAmount += Vector3.up * velocityY;

        playerBodyController.Move(moveAmount);


        //---mouse input---
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -45f, 90f);

        camera.localEulerAngles = new Vector3(pitch, yaw, 0);
    }
}
