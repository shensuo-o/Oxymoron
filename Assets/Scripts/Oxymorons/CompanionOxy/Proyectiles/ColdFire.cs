using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColdFire : StatsOximorones
{
    public float speed;
    public float normalSpeed;
    public GameObject companion;
    public Transform target;

    [SerializeField] private Vector3 Dir;

    private void Start()
    {
        companion = GameObject.Find("Companion");
        Destroy(this.gameObject, lifeTime);
        target = GameObject.Find("BruteTarget").transform;
    }

    void Update()
    {
        transform.position = companion.transform.position;

        Dir = target.position - transform.position;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    private void OnDestroy()
    {
        companion.gameObject.GetComponent<CompanionMovement>().setAim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            normalSpeed = other.gameObject.GetComponent<Enemy>().Speed;
            other.gameObject.GetComponent<Enemy>().Speed = speed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Enemy>().HP -= dmg * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<Enemy>().Speed = normalSpeed;
        }
    }
}
