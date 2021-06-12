using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public int scannerCheckID;

    public List<Door> linkedDoors;


    public void OpenDoors()
    {
        Debug.Log("Opening scanner doors " + gameObject.name);

        foreach (Door door in linkedDoors)
        {
            if (door.isOpened)
                door.CloseDoor();
                
            else
                door.OpenDoor();
        }
    }
    
}
