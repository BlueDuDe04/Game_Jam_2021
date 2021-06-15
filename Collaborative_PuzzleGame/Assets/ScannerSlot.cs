using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerSlot : MonoBehaviour
{
    public GameObject scannerPrefab;
    public List<Door> linkedDoors;
    bool scannerInSlot;


    private void OnTriggerEnter(Collider collider)
    {

        if (!scannerInSlot
        && collider.TryGetComponent<ScannerUpper>(out ScannerUpper collidedScanner))
        {
            collidedScanner.OnDrop();
            GameObject newBattery = Instantiate(scannerPrefab, parent: this.transform) as GameObject;
            //newBattery.transform.localPosition = new Vector3(0f, -0.25f, 0f);
            newBattery.transform.localPosition = new Vector3(-0.05f, 0.8f, -0.25f);
            Destroy(collidedScanner.gameObject);
            scannerInSlot = true;
            //OpenDoors();
            //----------ScannerIsActive();
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
