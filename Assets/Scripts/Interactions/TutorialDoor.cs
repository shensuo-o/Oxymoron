using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    private bool DoorCheck;
    public GameObject EmptyT1;
    public GameObject EmptyT2;
    public GameObject DoorT;

    private void Start()
    {
        DoorCheck = true;
    }
    private void Update()
    {
        DoorChecker();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EmptyT1 && DoorT != null)
        {
            DoorCheck = false;
            //DoorT.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == EmptyT2 && DoorT != null)
        {
            DoorCheck = true;
            //DoorT.SetActive(true);
        }
    }

    private void DoorChecker()
    {
        if (DoorCheck)
        {
            DoorT.SetActive(true);
            Debug.Log("desabochatesesamo");
        }
        else
        {
            DoorT.SetActive(false);
            Debug.Log("abretesesamo");
        }
    }
}
