using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform leif;
    [SerializeField] private float damp;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float offSet;

    private void Awake()
    {
        leif = GameObject.Find("Leif").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            offSet = 8;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            offSet = -4;
        } 
        else
        {
            offSet = 4;
        }
    }

    void FixedUpdate()
    {
        var targetPosition = leif.position + new Vector3(0, offSet, 0);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), ref velocity, damp);
    }
}
