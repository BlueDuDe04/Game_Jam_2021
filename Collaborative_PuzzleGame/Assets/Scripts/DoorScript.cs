using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool isActivated = false;

    Vector3 leftDoorOpenPosition;
    Vector3 rightDoorOpenPosition;

    Transform leftDoor;
    Transform rightDoor;

    Vector3 initialLeftDoorPosition;
    Vector3 initialRightDoorPosition;

    // Start is called before the first frame update
    void Start()
    {
        leftDoorOpenPosition = transform.Find("LeftDoorOpen").position;
        rightDoorOpenPosition = transform.Find("RightDoorOpen").position;

        leftDoor = transform.Find("Scifi_LeftDoor");
        rightDoor = transform.Find("Scifi_RightDoor");

        initialLeftDoorPosition = leftDoor.position;
        initialRightDoorPosition = rightDoor.position;
    }

    float doorOpenPercentDone = 0f;
    float doorClosePercentDone = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isActivated && leftDoor.position == leftDoorOpenPosition)
        {
            doorOpenPercentDone = 0f;
            doorClosePercentDone = 0f;
        }
        if (!isActivated && leftDoor.position == initialLeftDoorPosition)
        {
            doorOpenPercentDone = 0f;
            doorClosePercentDone = 0f;
        }

        if (!isActivated && leftDoor.position != initialLeftDoorPosition)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, initialLeftDoorPosition, doorClosePercentDone);
            doorClosePercentDone = doorClosePercentDone + 0.001f;

            rightDoor.position = Vector3.Lerp(rightDoor.position, initialRightDoorPosition, doorClosePercentDone);
            doorClosePercentDone = doorClosePercentDone + 0.001f;
        }
        else if (leftDoor.position != leftDoorOpenPosition && rightDoor.position != rightDoorOpenPosition && isActivated)
        {
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftDoorOpenPosition, doorOpenPercentDone);
            doorOpenPercentDone = doorOpenPercentDone + 0.001f;

            rightDoor.position = Vector3.Lerp(rightDoor.position, rightDoorOpenPosition, doorOpenPercentDone);
            doorOpenPercentDone = doorOpenPercentDone + 0.001f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        leftDoor.position = leftDoor.position;
        rightDoor.position = rightDoor.position;
    }
}
