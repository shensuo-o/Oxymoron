using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public ParticleSystem particles;

    private void OnCollisionEnter(Collision collision)
    {
        particles.Play();
        if (collision.gameObject.layer == 20)
        {
            particles.Play();
        }
    }
}
