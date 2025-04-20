using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSombria : OxyCompanion
{
    protected override void CheckQ()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Action();
        }
    }
    protected override void Action()
    {
        Debug.Log("Luz Sombria");
    }
}
