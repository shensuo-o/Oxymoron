using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTornado : MonoBehaviour
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

    public bool goHigh;
    public Transform targetHigh;
    public bool goEnd;
    public Transform targetEnd;
    public float timer;

    private void Awake()
    {
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
        coll = this.gameObject.GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (interactable)
        {
            Vector3 center = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
            Vector3 dir = transform.up;
            Quaternion orientation = transform.rotation;

            if(goHigh == false)
            {
                if (element.particles.activeInHierarchy)
                {
                    StartCoroutine(EnableColl(true));
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
            else if (goHigh == true)
            {
                float temp = 10;
                Leif.maxFallSpeed = 0;
                if (timer <= 0.5f)
                {
                    Leif.transform.position = Vector3.MoveTowards(Leif.transform.position, targetHigh.position, 50 * Time.deltaTime);
                    timer += Time.deltaTime;
                }
                else if (timer > 0.5f && timer <= 1)
                {
                    Leif.transform.position = Vector3.MoveTowards(Leif.transform.position, targetEnd.position, 50 * Time.deltaTime);
                    timer += Time.deltaTime;
                }
                else
                {
                    goHigh = false;
                    timer = 0;
                    Leif.maxFallSpeed = temp;
                }
            }
            
        }
    }

    private IEnumerator EnableColl(bool set)
    {
        yield return new WaitForSeconds(2.5f);
        coll.enabled = set;
    }

    private void OnTriggerEnter(Collider collision)
    {
        goHigh = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.up * detectorDistance / 2, new Vector3(detectorSize.x * 2, detectorDistance, detectorSize.z * 2));
    }
}
