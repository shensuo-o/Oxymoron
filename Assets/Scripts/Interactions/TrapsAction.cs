using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsAction : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Vector3 dir;
    [SerializeField] private Personaje Leif;
    public bool interactable;
    public Collider coll;
    public Element element;

    public Vector3 detectorSize = Vector3.one;
    public RaycastHit hit;
    public float detectorDistance = 10;
    public LayerMask mask;

    private void Awake()
    {
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
        coll = this.gameObject.GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (interactable)
        {
            Vector3 center = new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z);
            Vector3 dir = transform.up;
            Quaternion orientation = transform.rotation;

            if (element.particles.activeInHierarchy)
            {
                coll.enabled = true;
                if (Physics.BoxCast(center, detectorSize, dir, out hit, orientation, detectorDistance, mask))
                {
                    Leif.rb.AddForce((transform.position - Leif.transform.position).normalized * 0.07f, ForceMode.Force);
                }
            }
            else if (element.particles.activeInHierarchy == false)
            {
                coll.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Leif.TakeDamage(0, (dir * force));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.up * detectorDistance / 2, new Vector3(detectorSize.x * 2, detectorDistance, detectorSize.z * 2));
    }
}
