using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDamage : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private Personaje Leif;

    private void Awake()
    {
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage, (Leif.transform.position - transform.position).normalized);
        }
    }
}
