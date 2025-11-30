using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTornado : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Vector3 dir;
    [SerializeField] private GameObject target;
    [SerializeField] private Personaje Leif;
    public bool interactable;
    public Collider coll;
    public Element element;

    public Vector3 detectorSize = Vector3.one;
    public RaycastHit hit;
    public float detectorDistance = 10;
    public LayerMask mask;

    public float time1;
    public float time2;
    public float time3;

    public bool goTarget;
    public bool goLeif;
    public Transform targetHigh;
    public Transform targetMid;
    public Transform targetEnd;
    public float timer;
    public bool isLeif;

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

            if (element.particles.activeInHierarchy)
            {
                StartCoroutine(EnableColl(true));
                if (Physics.BoxCast(center, detectorSize, dir, out hit, orientation, detectorDistance, mask))
                {
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - hit.transform.gameObject.transform.position).normalized * 0.07f, ForceMode.Force);
                }
            }
            else if (element.particles.activeInHierarchy == false)
            {
                coll.enabled = false;
            }

            if (goLeif == true)
            {
                Leif.gravityOn = false;
                if (timer <= time1)
                {
                    Leif.transform.position = Vector3.MoveTowards(Leif.transform.position, targetHigh.position, 50 * Time.deltaTime);
                    timer += Time.deltaTime;
                }
                else if (timer > time1 && timer <= time2)
                {
                    Leif.transform.position = Vector3.MoveTowards(Leif.transform.position, targetMid.position, 50 * Time.deltaTime);
                    timer += Time.deltaTime;
                }
                else if (timer > time2 && timer <= time3)
                {
                    Leif.transform.position = Vector3.MoveTowards(Leif.transform.position, targetEnd.position, 50 * Time.deltaTime);
                    timer += Time.deltaTime;
                }
                else
                {
                    goLeif = false;
                    timer = 0;
                    Leif.gravityOn = true;
                }
            }

            if (goTarget == true)
            {
                target.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (target != null)
                {
                    target.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    target.GetComponent<Rigidbody>().useGravity = false;
                    if (timer <= time1)
                    {
                        target.transform.position = Vector3.MoveTowards(target.transform.position, targetHigh.position, 50 * Time.deltaTime);
                        timer += Time.deltaTime;
                    }
                    else if (timer > time1 && timer <= time2)
                    {
                        target.transform.position = Vector3.MoveTowards(target.transform.position, targetMid.position, 50 * Time.deltaTime);
                        timer += Time.deltaTime;
                    }
                    else if (timer > time2 && timer <= time3)
                    {
                        target.transform.position = Vector3.MoveTowards(target.transform.position, targetEnd.position, 50 * Time.deltaTime);
                        timer += Time.deltaTime;
                    }
                    else
                    {
                        goTarget = false;
                        timer = 0;
                        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        target.GetComponent<Rigidbody>().rotation = Quaternion.identity;
                        target.GetComponent<Rigidbody>().useGravity = true;
                        target.transform.position = targetEnd.position;
                    }
                    target.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
        if (collision.gameObject.layer == 20)
        {
            goTarget = true;
            target = collision.gameObject;
        }
        else if (collision.gameObject.layer == 7)
        {
            goLeif = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.up * detectorDistance / 2, new Vector3(detectorSize.x * 2, detectorDistance, detectorSize.z * 2));
    }
}
