using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoors : MonoBehaviour
{
    public GameObject thingToMove;
    public bool open;
    public float Vertical;

    private void Start()
    {
        open = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16 && other.gameObject.name == "Blue" && !open)
        {
            thingToMove.transform.position += new Vector3(0, Vertical, 0);

            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 16 && other.gameObject.name == "Blue" && open)
        {
            thingToMove.transform.position += new Vector3(0, -Vertical, 0);

            open = false;
        }
    }
}
