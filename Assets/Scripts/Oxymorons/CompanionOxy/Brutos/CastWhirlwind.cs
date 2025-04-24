using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWhirlwind : MonoBehaviour
{
    public Transform spawnPointR;

    public Transform spawnPointL;

    public GameObject vientoR;
    public GameObject vientoL;

    public GameObject leif;
    public bool dir;

    void Update()
    {
        if (leif.GetComponent<Personaje>().HorizontalInput == 1)
        {
            dir = true;
        }

        if (leif.GetComponent<Personaje>().HorizontalInput == -1)
        {
            dir = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (dir)
            {
                Instantiate(vientoR, spawnPointR.position, Quaternion.identity);
            }

            if (!dir)
            {
                Instantiate(vientoL, spawnPointL.position, Quaternion.identity);
            }
        }

    }
}
