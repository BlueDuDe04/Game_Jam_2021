using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPickup
{
    Rigidbody rb;
    FixedJoint fixedJoint;
    bool isHeld;
    public Transform PositionHolder;
    public float distance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }


    void Update()
    {        
        if(isHeld)
        {
            transform.position = PositionHolder.transform.position + PositionHolder.transform.forward * distance;
            transform.rotation = new Quaternion( 0.0f, PositionHolder.transform.rotation.y, 0.0f, PositionHolder.transform.rotation.w );
        }
    }

    public void OnDrop()
    {
        isHeld = false;
        GetComponent<Collider>().enabled = true;
        this.transform.parent = null;
        this.transform.GetComponent<Rigidbody>().useGravity = true;

        Destroy(fixedJoint);
        //InputHandler.Instance.GetComponent<CapsuleCollider>().enabled = false;
    }

    public void OnPickup()
    {
        isHeld = true;
        Debug.Log("Pick up this " + this.gameObject.name);
        GetComponent<Collider>().enabled = false;
        /*
        fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.breakForce = 10000f;

        
        transform.parent = InputHandler.Instance.heldObjectPlaceHolder;

        transform.localPosition = Vector3.zero;
        transform.rotation = InputHandler.Instance.heldObjectPlaceHolder.transform.rotation;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //

        fixedJoint.connectedBody = InputHandler.Instance.player.GetComponent<Rigidbody>();
        */
        
    }

}
