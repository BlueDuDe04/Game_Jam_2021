using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour, IInteractable
{
    string keyName = "";

    // Start is called before the first frame update
    void Start()
    {
        keyName = transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractWithObject()
    {
        //player clicked on key...

        //make noise

        //enter star

        //add to current Input variable
        string userInputCode = transform.GetComponentInParent<Keypad>().userInput;

        print(keyName);

        if(keyName != "Backspace")
        {
            int codeLength = transform.GetComponentInParent<Keypad>().userInput.Length;
            if (codeLength < 4)
            {
                transform.GetComponentInParent<Keypad>().userInput += keyName;
                transform.GetComponentInParent<Keypad>().ActivateNextStar();
            }
            else
            {
                //length of user's input code is at its limit
            }
        }
        else
        {
            transform.GetComponentInParent<Keypad>().userInput = userInputCode.Remove(userInputCode.Length - 1);
            transform.GetComponentInParent<Keypad>().DecrementStar();
        }
    }
}
