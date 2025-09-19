using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDamage : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private Personaje Leif;
    public bool interactable;
    public SphereCollider coll;
    public Element element;

    private void Awake()
    {
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
        coll = this.gameObject.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (interactable)
        {
            if (element.particles.activeInHierarchy)
            {
                coll.enabled = true;
            }
            else if(element.particles.activeInHierarchy == false)
            {
                coll.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(Damage, (Leif.transform.position - transform.position).normalized);
        }
    }
}
