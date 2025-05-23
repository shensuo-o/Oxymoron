using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoHelado : OxyCompanion
{
    protected override void CheckQ()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Action();
        }
    }
    protected override void Action()
    {
        Debug.Log("FuegoHelado");
    }
}
