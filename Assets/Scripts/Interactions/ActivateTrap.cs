using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public Collider detector;
    public Collider jaw1;
    public Collider jaw2;

    public Animator animator;

    public float coolDown;

    void Start()
    {
        detector = GetComponent<SphereCollider>();
        animator = GetComponent<Animator>();
        detector.enabled = true;
        jaw1.enabled = false;
        jaw2.enabled = false;
    }

    IEnumerator ActionAndReload()
    {
        detector.enabled = false;
        jaw1.enabled = true;
        jaw2.enabled = true;
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.3f);
        jaw1.enabled = false;
        jaw2.enabled = false;
        yield return new WaitForSeconds(coolDown);
        animator.SetTrigger("Open");
        detector.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 || other.gameObject.layer == 27)
        {
            StartCoroutine(ActionAndReload());
        }
    }
}
