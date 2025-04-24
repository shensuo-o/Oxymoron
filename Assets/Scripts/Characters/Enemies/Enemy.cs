using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float Speed;
    public Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
