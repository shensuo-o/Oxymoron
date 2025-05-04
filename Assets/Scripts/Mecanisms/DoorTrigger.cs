using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject plataform;
    public bool open;

    private void Start()
    {
        open = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && !open)
        {
            door.transform.position += new Vector3(0, 11, 0);
            plataform.transform.position += new Vector3(0, 4, 0);
            open = true;
        }
    }
}
