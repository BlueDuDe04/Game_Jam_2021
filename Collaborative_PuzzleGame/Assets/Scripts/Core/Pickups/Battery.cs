using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IPickup
{
    Rigidbody rb;
    BoxCollider collider;
    bool isHeld;
    public Transform mirroredObject; 
    public Transform MirrorPoint;
    public float offsetZ;
    public float offsetX;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();

    }
    
    private void LateUpdate() 
    {
        
        if (mirroredObject != null
        && isHeld)
        {
            
            //mirroredObject.position = Vector3.LerpUnclamped(this.transform.parent.position, MirrorPoint.position, 3f);
            
            float posX = Mathf.LerpUnclamped(transform.parent.position.x, MirrorPoint.position.z, offsetX);;
            float posY = transform.parent.position.y;
            float posZ = Mathf.LerpUnclamped(transform.parent.position.z, MirrorPoint.position.z, offsetZ);

            mirroredObject.transform.position = new Vector3(posX, posY, posZ);
            //Transform playerPos = this.transform.parent.parent.parent.parent.transform;
            //mirroredObject.transform.position = playerPos.position;

        }
    }


    public void OnDrop()
    {
        rb.ResetCenterOfMass();
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * 700);

        isHeld = false;
        this.transform.parent = null;

        collider.isTrigger = false;

        //GetComponent<Collider>().enabled = true;
        rb.constraints = RigidbodyConstraints.None;
        this.transform.parent = null;

        if (mirroredObject != null)
            mirroredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        
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
        rb.IsSleeping();


        if (mirroredObject != null)
            mirroredObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;


        
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Wall")
        {
            Debug.Log("You hit a wall bitch");
            OnDrop();
            
            
        }
        
    }

}