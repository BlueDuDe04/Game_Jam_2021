using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPickup
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    public void OnDrop()
    {
        this.transform.parent = null;
        this.transform.GetComponent<Rigidbody>().useGravity = true;
        //InputHandler.Instance.GetComponent<CapsuleCollider>().enabled = false;
    }

    public void OnPickup()
    {
        Debug.Log("Pick up this " + this.gameObject.name);
        
    }

}
