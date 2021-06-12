using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    Camera mainCamera;

    public bool isGrabbing = false;
    Transform grabbedObject = null;

    float timeGrabbed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.parent.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray beam = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(beam.origin, beam.direction * 100f, Color.red);
        bool didHit = Physics.Raycast(beam, out hit, 300f);

        //if the raycast hit a "PickUp" object, continue to process raycast...
        if (didHit) { 
            if (!hit.Equals(null) && hit.transform.tag.Equals("PickUps"))
                didHit = true;
            else
            {
                //----if not a pickup, check to see if button----
                if(!hit.Equals(null) && hit.transform.tag.Equals("Button"))
                {
                    //if within distance
                    if(hit.distance <= 4f && Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.GetComponent<ButtonScript>().activateDoor = true; //can only push button ON
                    }
                }

                didHit = false;
            }
        }

        //if aren't grabbing/holding something and press E and within distance -> start grabbing 
        if(!isGrabbing && didHit && Input.GetKeyDown(KeyCode.E) && hit.distance <= 4f)
        {
            isGrabbing = true;
            grabbedObject = hit.transform;
            grabbedObject.parent = transform;
            (grabbedObject.GetComponent<Rigidbody>()).useGravity = false;

            Collider collide = grabbedObject.GetComponent<Collider>();
            //collide.enabled = false;

            grabbedObject.GetComponent<Grabbable>().isGrabbed = true;
            timeGrabbed = Time.time;
        }

        //if you are holding something, continue to hold it (else branch)... if you are holding something and press E -> release object
        if (isGrabbing)
        {
            if (Input.GetKeyDown(KeyCode.E) && Time.time - timeGrabbed > 0.01f)
            {
                //release object
                isGrabbing = false;
                grabbedObject.GetComponent<Grabbable>().isGrabbed = false;

                grabbedObject.parent = null;
                (grabbedObject.GetComponent<Rigidbody>()).useGravity = true;
                (grabbedObject.GetComponent<Rigidbody>()).velocity = transform.parent.parent.parent.GetComponent<CharacterController>().velocity;

                Collider collide = grabbedObject.GetComponent<Collider>();
                collide.enabled = true;
            }
            else
            {
                //is grabbing object... Update position, etc
                grabbedObject.position = transform.position;
                grabbedObject.localEulerAngles = new Vector3(45, 0, 0);
                grabbedObject.eulerAngles = new Vector3(0, grabbedObject.eulerAngles.y, grabbedObject.eulerAngles.z);
            }
        }
    }
}
