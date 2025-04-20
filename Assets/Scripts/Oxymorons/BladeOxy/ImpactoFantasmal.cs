using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactoFantasmal : OxyBlade
{
    protected override void CheckE()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Alpha5))
        {
            Action();
        }
    }
    protected override void Action()
    {
        Debug.Log("Impacto fantasmal");
    }
}
