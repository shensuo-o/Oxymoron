using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OximoronInventory : MonoBehaviour
{
    public static OximoronInventory Instance { get; private set; }
    public Oximorons[] allOximorons = new Oximorons[1];

    private void Awake()
    {
        Instance = this;
    }
}
