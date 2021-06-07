using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    float yaw;  //left/right
    float pitch;    //up/down

    Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = (GetComponentInChildren<Camera>()).transform;
    }

    // Update is called once per frame
    void Update()
    {
        //---move player---
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput = moveInput.normalized;

        Vector3 moveAmount = moveInput.x * (new Vector3(camera.right.x, 0, camera.right.z)) + moveInput.y * (new Vector3(camera.forward.x, 0, camera.forward.z));   //move to the right as specified by input, and also forward/backward as specified...
        moveAmount = moveAmount * 10f * Time.deltaTime;

        transform.Translate(moveAmount, Space.Self);


        //---mouse input---
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, -45f, 90f);

        camera.transform.localEulerAngles = new Vector3(pitch, yaw, 0);
    }
}
