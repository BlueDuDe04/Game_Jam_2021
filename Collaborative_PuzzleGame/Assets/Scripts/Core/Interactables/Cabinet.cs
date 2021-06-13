using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet : MonoBehaviour, IInteractable
{
    private Animator anim;
    public bool isOpened;

    


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InteractWithObject()
    {
        if (!isOpened)
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
