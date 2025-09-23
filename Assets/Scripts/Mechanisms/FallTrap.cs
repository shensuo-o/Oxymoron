using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    public Vector3 detectorSize = Vector3.one;
    public float detectorDistance = 10;
    public RaycastHit hit;
    public LayerMask mask;
    public ParticleSystem particlesTell;
    public ParticleSystem particlesFall;

    public bool active = true;
    public float force;

    public Rigidbody proyectile;
    public Rigidbody topHalf;
    public Rigidbody bottomHalf;

    private void FixedUpdate()
    {
        Vector3 center = transform.position;
        Vector3 dir = -transform.up;
        Quaternion orientation = transform.rotation;

        if (active)
        {
            if (Physics.BoxCast(center, detectorSize, dir, out hit, orientation, detectorDistance, mask))
            {
                proyectile.useGravity = true;
                topHalf.useGravity = true;
                bottomHalf.useGravity = true;
                particlesFall.Play();
                proyectile.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                proyectile.AddForce(-transform.up * force, ForceMode.Impulse);
                topHalf.AddForce(-transform.up * (force * 0.0009f), ForceMode.Impulse);
                bottomHalf.AddForce(-transform.up * (force * 0.0009f), ForceMode.Impulse);
                particlesTell.Stop();
                active = false;
            }
        }
    }

    public void ResetTrap()
    {
        if (!active)
        {
            proyectile.GetComponent<EnviromentProjectile>().ResetProjectile();
            proyectile.transform.position = transform.position;
            proyectile.transform.rotation = transform.rotation;
            topHalf.transform.position = new Vector3 (0, 0.69f, 0);
            bottomHalf.transform.position = new Vector3(0, -0.9f, 0);
            topHalf.transform.rotation = transform.rotation;
            bottomHalf.transform.rotation = transform.rotation;
            proyectile.useGravity = false;
            topHalf.useGravity = false;
            bottomHalf.useGravity = false;
            proyectile.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            particlesTell.Play();
            active = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(-Vector3.up * detectorDistance / 2, new Vector3 (detectorSize.x * 2, detectorDistance, detectorSize.z * 2));
    }
}
