using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform[] location = new Transform[5];
    public GameObject leif;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            leif.transform.position = location[0].position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            leif.transform.position = location[1].position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            leif.transform.position = location[2].position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            leif.transform.position = location[3].position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            leif.transform.position = location[4].position;
        }

    }
}
