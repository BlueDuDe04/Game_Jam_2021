using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<Door> linkedDoors;

    private void OnCollisionEnter(Collision other) 
    {
        //Play Animation of button sinking when asset is made
        Debug.Log("Opening pressure plate doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.OpenDoor();
        
    }

    private void OnCollisionExit(Collision other) 
    {
         //Play Animation of button sinking when asset is made
        Debug.Log("Closing pressure plate doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.CloseDoor();
               
    }

    
}
