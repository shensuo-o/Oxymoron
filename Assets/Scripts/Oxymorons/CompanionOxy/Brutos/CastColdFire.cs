using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColdFire : MonoBehaviour
{
    public Transform target;
    public GameObject fire;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(fire, target.position, Quaternion.identity);
        }
    }
}
