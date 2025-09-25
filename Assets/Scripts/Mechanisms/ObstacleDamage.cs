using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity;
    public float threshHold;
    public float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity = rb.velocity.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (velocity >= threshHold)
            {
                other.gameObject.GetComponent<Personaje>().TakeDamage(damage, Vector3.one / 2);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
