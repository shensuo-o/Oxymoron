using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentProjectile : MonoBehaviour
{
    public float dmg;
    public MeshRenderer mesh;
    public ParticleSystem particles;
    public BoxCollider trigger;

    private void OnImpact()
    {
        mesh.enabled = false;
        particles.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            OnImpact();
            other.GetComponent<Personaje>().TakeDamage(dmg, Vector3.one);
            trigger.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnImpact();
            trigger.enabled = false;
        }
    }
}
