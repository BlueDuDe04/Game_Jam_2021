using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySlot : MonoBehaviour
{
    public GameObject batteryPrefab;
    public GameObject batteryFull;
    public List<Door> linkedDoors;
    bool powered;


    private void OnTriggerEnter(Collider collider) 
    {

        if (!powered 
        && collider.TryGetComponent<Battery>(out Battery collidedBattery))
        {
            collidedBattery.OnDrop();
            Destroy(collidedBattery.gameObject);
            Destroy(transform.Find("Cube_007"));

            GameObject newSlot = Instantiate(batteryFull, transform.position, transform.rotation);
            powered = true;
            OpenDoors();
        }

        return;

        
    }

    public void OpenDoors()
    {
        Debug.Log("Opening battery doors " + gameObject.name);

        foreach (Door door in linkedDoors)
            door.OpenDoor();
    }
}
