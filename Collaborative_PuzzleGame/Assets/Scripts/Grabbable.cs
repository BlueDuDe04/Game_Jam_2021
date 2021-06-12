using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Player object needs tag "Player"!!!
        if(isGrabbed && !collision.transform.tag.Equals("Player"))
        {
            transform.parent.GetComponent<GrabScript>().isGrabbing = false;
            isGrabbed = false;

            transform.parent = null;
            (transform.GetComponent<Rigidbody>()).useGravity = true;
            (transform.GetComponent<Rigidbody>()).velocity = transform.parent.parent.parent.GetComponent<CharacterController>().velocity;

            transform.GetComponent<Collider>().enabled = true;
        }

    }
}
