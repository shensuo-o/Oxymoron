using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Whirlwind : StatsOximorones
{
    public float speed;
    [SerializeField] private Transform pointEffect;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 16)
        {
            timer += Time.deltaTime;
            if (other.gameObject.GetComponent<Collider>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, pointEffect.position, force * Time.deltaTime);
                if (timer >= lifeTime - 0.5f)
                {
                    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 16)
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
