using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform leif;

    private void Awake()
    {
        leif = GameObject.Find("Leif").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = new Vector3 (leif.position.x, leif.position.y + 4, transform.position.z);
    }
}
