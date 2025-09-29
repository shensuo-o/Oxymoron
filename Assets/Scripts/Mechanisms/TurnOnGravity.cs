using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TurnOnGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float time;
    public GameObject obj;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (obj == null && rb.useGravity == false)
        {
            time += Time.deltaTime;

            if (time >= 0.01f)
            {
                rb.useGravity = true;
                time = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        obj =  other.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.useGravity = true;
    }
}
