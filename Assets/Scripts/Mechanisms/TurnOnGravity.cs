using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TurnOnGravity : MonoBehaviour
{
    public Rigidbody rb;
    public float time;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.useGravity == false)
        {
            time += Time.deltaTime;

            if (time >= 0.1f)
            {
                rb.useGravity = true;
                time = 0;
            }
        }
    }
}
