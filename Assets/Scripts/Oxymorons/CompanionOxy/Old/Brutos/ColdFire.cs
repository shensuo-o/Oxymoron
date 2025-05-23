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
    public Camera cam;

    private void Start()
    {
        companion = GameObject.Find("Mira (1)").transform;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        target = GameObject.Find("BruteTarget").transform;
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        transform.position = companion.position;

        transform.rotation = Quaternion.LookRotation(target.position.normalized, target.position.normalized);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Enemy>().HP -= dmg * Time.deltaTime;
        }
    }
}
