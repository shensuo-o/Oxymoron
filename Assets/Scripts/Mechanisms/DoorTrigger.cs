using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject thingToMove;
    public bool open;
    public float Vertical;
    public int layer;

    private void Start()
    {
        open = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer && !open)
        {
            thingToMove.transform.position += new Vector3(0, Vertical, 0);

            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layer && open)
        {
            thingToMove.transform.position += new Vector3(0, -Vertical, 0);

            open = false;
        }
    }
}
