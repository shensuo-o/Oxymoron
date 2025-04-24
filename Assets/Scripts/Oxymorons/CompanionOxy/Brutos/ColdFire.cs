using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdFire : MonoBehaviour
{
    public int dmg;
    public float lifeTime;
    public float speed;
    public Transform companion;
    public Transform target;

    private void Start()
    {
        companion = GameObject.Find("Mira (1)").transform;
        target = GameObject.Find("BruteTarget").transform;
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.position = companion.position;
        Vector3 direction = Vector3.RotateTowards(transform.forward, target.position, speed, 0f);
        Debug.Log(direction);
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Enemy>().HP -= dmg * Time.deltaTime;
        }
    }
}
