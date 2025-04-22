using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWhirlwind : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject viento;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(viento, spawnPoint.position, Quaternion.identity);
        }

    }
}
