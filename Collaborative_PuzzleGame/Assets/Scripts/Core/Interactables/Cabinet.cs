using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : Door, IInteractable
{  
    void Start() => base.Start();
    

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
