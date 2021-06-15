using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerUpper : MonoBehaviour, IPickup
{
    public int scannerCheckID = 0;

    public List<Door> linkedDoors;

    Rigidbody rb;
    bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isHeld)
        {
            transform.localEulerAngles = new Vector3(-90, 180, 0);
            transform.eulerAngles = new Vector3(transform.localEulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    public void OnPickup()
    {
        isHeld = true;
        Debug.Log("Pick up this " + this.gameObject.name);


        GetComponentInChildren<Collider>().isTrigger = true;
        transform.parent = InputHandler.Instance.heldObjectPlaceHolder;
        transform.position = InputHandler.Instance.heldObjectPlaceHolder.position;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void OnDrop()
    {
        isHeld = false;


        rb.constraints = RigidbodyConstraints.None;
        this.transform.parent = null;
        GetComponentInChildren<Collider>().isTrigger = false;
    }



    public void OpenDoors()
    {
        Debug.Log("Opening scanner doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.OpenDoor();
    }

    public void CloseDoors()
    {
        Debug.Log("Closing scanner doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.CloseDoor();
    }

}
