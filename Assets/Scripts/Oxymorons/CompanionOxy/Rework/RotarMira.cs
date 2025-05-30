using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarMira : MonoBehaviour
{
    [SerializeField] private Personaje Leif;

    void Awake()
    {
        Leif = GameObject.Find("Leif").GetComponent<Personaje>();
    }

    void Update()
    {
        if (Leif.HorizontalInput == 1)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Leif.HorizontalInput == -1)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
