using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public DoorScript doorScript;
    Light buttonLight;

    public bool activateDoor = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(activateDoor == true)
        {
            doorScript.isActivated = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.name == "HandGrab")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorScript.isActivated)
                    doorScript.isActivated = false;
                else
                    doorScript.isActivated = true;
            }
        }
    }
}
