using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour, IPickup
{
    public int scannerID;
    Rigidbody rb;
    bool isHeld;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void OnDrop()
    {
        isHeld = false;

        
        rb.constraints = RigidbodyConstraints.None;
        this.transform.parent = null;
        GetComponent<Collider>().isTrigger = false;
    }

    public void OnPickup()
    {
        isHeld = true;
        Debug.Log("Pick up this " + this.gameObject.name);
        

        GetComponent<Collider>().isTrigger = true;
        transform.parent = InputHandler.Instance.heldObjectPlaceHolder;
        transform.rotation = InputHandler.Instance.camera.transform.rotation;
        transform.position = transform.parent.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter(Collider collider)
    {
         if(collider.tag == "Wall")
        {
            Debug.Log("You hit a wall bitch");
            GetComponent<Collider>().isTrigger = false;
            OnDrop();
        }


        else if (collider.tag == "Scanner")
        {
            Scanner scanner = collider.GetComponent<Scanner>();
            if(scannerID == scanner.scannerCheckID)
            {
                scanner.OpenDoors();
            }
        }
    }

    private void OnTriggerExit(Collider collider) 
    {
        if (collider.tag == "Scanner")
        {
            Scanner scanner = collider.GetComponent<Scanner>();
            if(scannerID == scanner.scannerCheckID)
            {
                scanner.CloseDoors();
            }
        }
    }
}

