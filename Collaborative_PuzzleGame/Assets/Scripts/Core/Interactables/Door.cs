using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened;
    public bool isLocked;

    Animator anim;

    GameObject onLights;
    GameObject offLights;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        onLights = transform.Find("Sifi_Sliding_DoorLights_On").gameObject;
        offLights = transform.Find("Sifi_Sliding_DoorLights_Off").gameObject;

    }

    public void OpenDoor()
    {
        if (isOpened == false && !isLocked)
        {
            anim.SetTrigger("Open");
            isOpened = true;
            onLights.SetActive(true);
            offLights.SetActive(false);
        }
        
    }

    public void CloseDoor()
    {
        if (isOpened)
        {
            anim.SetTrigger("Close");
            isOpened = false;
            onLights.SetActive(false);
            offLights.SetActive(true);
        }


    }
    
}
