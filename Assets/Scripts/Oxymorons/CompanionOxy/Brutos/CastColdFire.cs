using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColdFire : MonoBehaviour
{
    public Transform target;
    public GameObject fire;

    public int charges;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (charges >= 1)
            {
                Instantiate(fire, target.position, Quaternion.identity);
                charges--;
            }
        }
    }
}
