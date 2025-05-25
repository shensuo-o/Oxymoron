using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oximorons : MonoBehaviour
{
    public string neededElement1;
    public string neededElement2;
    public Sprite icon;
    public OximoronSlot slot;

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void ClearSlot()
    {
        slot.ClearSlot();
    }
}
