using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoInstantaneo : OxyBlade
{
    protected override void CheckE()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Alpha4))
        {
            Action();
        }
    }
    protected override void Action()
    {
        Debug.Log("Eco Instantaneo");
    }
}
