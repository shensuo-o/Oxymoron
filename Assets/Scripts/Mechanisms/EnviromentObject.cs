using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentObject : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            Debug.Log("atravezo");
            direction = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-5.0f, 5.0f), Random.Range(-2.0f, 2.0f));
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
