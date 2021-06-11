using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = -22f;
    float velocityY;

    public float mouseSensitivity = 5f;
    float yaw;  //left/right
    float pitch;    //up/down

    Transform camera;

    CharacterController playerBodyController;

    Transform HandGrab;

    bool isCrouching = false;
    Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        camera = (GetComponentInChildren<Camera>()).transform;
        playerBodyController = GetComponent<CharacterController>();

        HandGrab = transform.Find("HandGrab");

        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //---crouch---
        bool pressCrouch = Input.GetKeyDown(KeyCode.LeftControl);

        if (!isCrouching)
        {
            if (pressCrouch)
            {
                transform.localScale = initialScale * 0.5f;
                isCrouching = true;
            }
        }
        else
        {
            if (pressCrouch)
            {
                transform.localScale = initialScale;
                isCrouching = false;
            }
        }

        //---move player---
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;

        float moveSpeed = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 22f;
        else
            moveSpeed = 13f;

        Vector3 moveAmount = moveInput.x * (new Vector3(camera.right.x, 0, camera.right.z)) + moveInput.y * transform.forward;   //move to the right as specified by input, and also forward/backward as specified...
        moveAmount = moveAmount * moveSpeed;

        //velocityY += gravity * Time.deltaTime;
        //moveAmount += Vector3.up * velocityY;

        //playerBodyController.Move(moveAmount);

        //velocityY += gravity * Time.deltaTime;

        //-----Jump-----
        velocityY += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && playerBodyController.isGrounded)
        {
            velocityY = 8f;
        }

        moveAmount.y = velocityY;

        playerBodyController.Move(moveAmount * Time.deltaTime);


        //---mouse input---
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -45f, 90f);

        transform.eulerAngles = new Vector3(0, yaw, 0);
        camera.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
