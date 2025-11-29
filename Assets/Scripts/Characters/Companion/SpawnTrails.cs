using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrails : MonoBehaviour
{
    public GameObject trail;
    public TrailRenderer trailRenderer;
    public Transform target;
    public bool moveOn;

    private void Update()
    {
        if (moveOn == true)
        {
            trail.transform.position = Vector3.MoveTowards(trail.transform.position, target.position, 10 * Time.deltaTime);
            trailRenderer.time -=  12 * Time.deltaTime;
        }
        else if (moveOn == false)
        {
            trail.transform.position = transform.position;
            trailRenderer.time = 10f;
        }
    }
}
