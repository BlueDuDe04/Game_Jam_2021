using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Door, IInteractable
{
    private Animator anim;

    


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InteractWithObject()
    {
        if (!isOpened && !isLocked)
        {
            isOpened = true;
            anim.SetTrigger("Open");
            GetComponent<BoxCollider>().enabled = false;
            return;
        }
        

        isOpened = false;
        anim.SetTrigger("Close");
        
    }


}
