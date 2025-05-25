using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLight : Oximorons
{
    public GameObject proyectile;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 18;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(proyectile, pos, Quaternion.identity);
            TurnOff();
            ClearSlot();
        }
    }
}
