using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera roomVCam;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<PlayerMovement>() == true)
        {
            roomVCam.Priority = 20;
            roomVCam.LookAt = collider.transform;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.GetComponent<PlayerMovement>() == true)
        {
            roomVCam.Priority = 1;
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }
}
