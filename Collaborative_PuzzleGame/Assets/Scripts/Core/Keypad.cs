using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public int code = 5793;
    public Collider[] keys;
    public GameObject[] stars;
    public int lastStarActiveIndex = 0;

    public string userInput = "";

    public Door unlockDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(userInput.Length == 4)
        {
            if(userInput == code.ToString())
            {
                unlockDoor.OpenDoor();
            }
            else
            {
                //got the code wrong!
                userInput = "";
                for(int i=0; i<4; i++)
                {
                    stars[i].SetActive(false);
                }
                lastStarActiveIndex = 0;
            }
        }
    }

    public void ActivateNextStar()
    {
        stars[lastStarActiveIndex].SetActive(true);
        lastStarActiveIndex++;
    }

    public void DecrementStar()
    {
        stars[lastStarActiveIndex].SetActive(false);
        lastStarActiveIndex--;
    }
}
