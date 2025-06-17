using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float lenght;
    [SerializeField] private float startPos;
    [SerializeField] private Transform cam;
    [SerializeField] private float parallaxAmount;
    
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = cam.position.x * (1 - parallaxAmount);
        Debug.Log("temp " + temp);

        float dist = cam.position.x * parallaxAmount;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if(temp < startPos - lenght) 
        {
            startPos -= lenght;
        }
    }
}
