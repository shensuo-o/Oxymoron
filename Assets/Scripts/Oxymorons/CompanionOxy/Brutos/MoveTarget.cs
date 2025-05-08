using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 18;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = pos;   
    }
}
