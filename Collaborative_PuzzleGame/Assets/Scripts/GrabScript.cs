using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    Transform gameCube;
    bool isGrabbing = false;

    bool pressGrab = false;
    float timeGrabed = 0f;
    float timeLeft = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //(GetComponent<Rigidbody>()).isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Time: " + Time.time);
        pressGrab = Input.GetKeyDown(KeyCode.E);
        if (pressGrab)
            timeGrabed = Time.time;

        if (isGrabbing)
        {
            if (pressGrab)
            {
                isGrabbing = false;

                gameCube.parent = null;
                (gameCube.transform.GetComponent<Rigidbody>()).useGravity = true;
                transform.GetComponent<CapsuleCollider>().enabled = false;

                timeLeft = Time.time;
            }
            else
            {
                gameCube.position = transform.position;
                gameCube.localEulerAngles = new Vector3(45, 0, 0);
                gameCube.eulerAngles = new Vector3(0, gameCube.eulerAngles.y, gameCube.eulerAngles.z);
            }
        }

        if (Time.time > 1 && Time.time - timeLeft > 1.5f)
            transform.GetComponent<CapsuleCollider>().enabled = true;
    }



    private void OnTriggerStay(Collider other)
    {
        if(!isGrabbing && other.transform.name == "Cube Test")
        {
            if (Time.time > 1 && Time.time - timeGrabed <= 1)
            {
                print("Pressed grab");

                transform.GetComponent<CapsuleCollider>().enabled = false;

                isGrabbing = true;
                gameCube = other.transform;

                other.transform.parent = transform;
                other.transform.position = transform.position;
                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                rb.useGravity = false;
            }
        }
    }
}
