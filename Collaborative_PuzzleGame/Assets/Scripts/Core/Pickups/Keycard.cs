using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour, IPickup
{
    public int scannerID;

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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Scanner")
        {
            Scanner scanner = collider.GetComponent<Scanner>();
            if(scannerID == scanner.scannerCheckID)
            {
                scanner.OpenDoors();
            }
        }
    }
}
