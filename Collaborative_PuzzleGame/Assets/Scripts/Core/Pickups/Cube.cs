using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPickup
{
    Rigidbody rb;
    bool isHeld;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    public void OnDrop()
    {
        GetComponent<Collider>().isTrigger = false;
        isHeld = false;

        //GetComponent<Collider>().enabled = true;
        rb.constraints = RigidbodyConstraints.None;
        this.transform.parent = null;
        
    }

    public void OnPickup()
    {
        isHeld = true;
        Debug.Log("Pick up this " + this.gameObject.name);
        GetComponent<Collider>().isTrigger = true;
        //GetComponent<Collider>().enabled = false;

    
        transform.parent = InputHandler.Instance.heldObjectPlaceHolder;
        transform.rotation = InputHandler.Instance.camera.transform.rotation;
        transform.position = transform.parent.position;


        rb.constraints = RigidbodyConstraints.FreezeAll;
        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Wall")
        {
            Debug.Log("You hit a wall bitch");
            GetComponent<Collider>().isTrigger = false;
            OnDrop();
        }
        
    }

}
