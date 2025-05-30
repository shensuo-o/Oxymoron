using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Whirlwind : StatsOximorones
{
    public float speed;

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
            Debug.Log("pego tornado");
            other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, force * Time.deltaTime);
        }
    }
}
