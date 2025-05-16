using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public float Speed;
    public Rigidbody RB;
    public float Damage;
    public Personaje Leif;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage);
        }

        if (collision.gameObject.layer == 21)
        {
            HP -= Leif.Damage;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage * Time.deltaTime);
        }
    }
}
