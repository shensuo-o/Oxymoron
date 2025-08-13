using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform leif;
    [SerializeField] private float damp;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private float offSet;
    [SerializeField] private float offSetSpeed;

    private void Awake()
    {
        leif = GameObject.Find("Leif").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            offSet += offSetSpeed * Time.deltaTime;
            offSet = Mathf.Clamp(offSet, 0, 8);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            offSet -= offSetSpeed * Time.deltaTime;
            offSet = Mathf.Clamp(offSet, 0, 8);
        } 
        else
        {
            if (offSet > 4)
            {
                offSet -= offSetSpeed * Time.deltaTime;
                offSet = Mathf.Clamp(offSet, 4, 8);
            }
            else if(offSet < 4)
            {
                offSet += offSetSpeed * Time.deltaTime;
                offSet = Mathf.Clamp(offSet, 0, 4);
            }
            else
            {
                offSet = 4;
            }
        }
    }

    void FixedUpdate()
    {
        var targetPosition = leif.position + new Vector3(0, offSet, 0);
        Vector3 temp = Vector3.SmoothDamp(transform.position, new Vector3(targetPosition.x, targetPosition.y, transform.position.z), ref velocity, damp);
        transform.position = new Vector3(temp.x, leif.transform.position.y + offSet , temp.z);
    }
}
