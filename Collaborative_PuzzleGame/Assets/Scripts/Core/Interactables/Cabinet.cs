using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Door, IInteractable
{
    private Animator animation;

    


    void Start()
    {
        animation = GetComponent<Animator>();
    }

    public void InteractWithObject()
    {
        if (!isOpened && !isLocked)
        {
            isOpened = true;
            animation.SetTrigger("Open");
            GetComponent<BoxCollider>().enabled = false;
            return;
        }
        

        isOpened = false;
        animation.SetTrigger("Close");
        
    }


}
