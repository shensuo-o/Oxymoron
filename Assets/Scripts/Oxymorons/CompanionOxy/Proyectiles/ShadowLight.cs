using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLightCast : StatsOximorones
{
    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 16)
        {
            other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, force * Time.deltaTime);
        }
    }
}
