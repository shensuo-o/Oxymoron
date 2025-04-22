using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLightCast : MonoBehaviour
{
    public int dmg;
    public float lifetime;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.transform.position = transform.position + new Vector3 (Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), transform.position.z);
            other.gameObject.GetComponent<Enemy>().HP -= dmg * Time.deltaTime;
        }
    }
}
