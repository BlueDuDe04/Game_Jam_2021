using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public List<Door> linkedDoors;
    public List<Cabinet> linkedCabinets;
    public bool isActivated;

    public void InteractWithObject()
    {
        Debug.Log("Interacted with " + gameObject.name);

        foreach (Door door in linkedDoors)
        {
            if (door.isOpened)
                door.CloseDoor();
                
            else
                door.OpenDoor();
        }


        foreach (Cabinet cabinet in linkedCabinets)
            cabinet.isLocked = false;
    }
}

