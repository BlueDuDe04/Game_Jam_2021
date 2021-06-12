using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySlot : MonoBehaviour
{
    public GameObject batteryPrefab;
    public List<Door> linkedDoors;
    bool powered;


    private void OnTriggerEnter(Collider collider) 
    {

        if (!powered 
        && collider.TryGetComponent<Battery>(out Battery collidedBattery))
        {
            collidedBattery.OnDrop();
            GameObject newBattery = Instantiate(batteryPrefab, parent: this.transform) as GameObject;
            newBattery.transform.localPosition = new Vector3(0f, -0.25f, 0f);
            Destroy(collidedBattery.gameObject);
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
