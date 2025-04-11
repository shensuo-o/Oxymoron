using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxyBlade : Oxymorones
{
    [SerializeField] public GameObject Weapon; //Espada.

    protected void CheckE()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            Action();
        }
    }
}
