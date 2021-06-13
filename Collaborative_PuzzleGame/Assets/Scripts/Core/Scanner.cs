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
            door.OpenDoor();
    }

    public void CloseDoors()
    {
        Debug.Log("Closing scanner doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.CloseDoor();       
    }



    
}
