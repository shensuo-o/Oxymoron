using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : MonoBehaviour
{
    public GameObject proyectile;
    public Transform target;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //target.position = Input.mousePosition;
            Instantiate(proyectile, target);
        }
    }
}
