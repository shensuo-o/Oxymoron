using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : MonoBehaviour
{
    public GameObject proyectile;

    public int charges;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (charges >= 1)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 18;
                Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(proyectile, pos, Quaternion.identity);
                charges--;
            }
        }
    }
}
