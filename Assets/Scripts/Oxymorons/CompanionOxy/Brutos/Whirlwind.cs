using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Whirlwind : MonoBehaviour
{
    public int dmg;
    public float lifeTime;
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
        if (other.gameObject.layer == 10)
        {
            other.gameObject.transform.position = transform.position + new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(0.5f, 3f), transform.position.z);
            other.gameObject.GetComponent<Enemy>().HP -= dmg * Time.deltaTime;
        }
    }
}
