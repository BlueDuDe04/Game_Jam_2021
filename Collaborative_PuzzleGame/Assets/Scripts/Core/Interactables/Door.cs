using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened;
    public bool isLocked;
    Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();    
    }

    public void OpenDoor()
    {
        if (isOpened == false && !isLocked)
        {
            anim.SetTrigger("Open");
            isOpened = true;
        }
        
    }

    public void CloseDoor()
    {
        if (isOpened)
        {
            anim.SetTrigger("Close");
            isOpened = false;
        }


    }
    
}
