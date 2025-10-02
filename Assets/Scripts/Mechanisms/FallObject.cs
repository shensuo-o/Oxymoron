using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    public Vector3 detectorSize = Vector3.one;
    public float detectorDistance = 10;
    public RaycastHit hit;
    public LayerMask mask;
    public Rigidbody objeto;

    private void FixedUpdate()
    {
        Vector3 center = transform.position;
        Vector3 dir = -transform.up;
        Quaternion orientation = transform.rotation;

        if (Physics.BoxCast(center, detectorSize, dir, out hit, orientation, detectorDistance, mask))
        {
            objeto.useGravity = true;
            objeto.constraints = RigidbodyConstraints.None;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(-Vector3.up * detectorDistance / 2, new Vector3(detectorSize.x * 2, detectorDistance, detectorSize.z * 2));
    }
}
