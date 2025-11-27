using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 50;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        this.transform.position = pos;
    }
}
