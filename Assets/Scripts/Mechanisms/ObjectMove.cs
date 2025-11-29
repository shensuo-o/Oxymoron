using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        this.transform.position = new Vector3 (target.position.x, target.position.y, target.position.z - 2);
    }
}
