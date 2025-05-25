using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oximorons : MonoBehaviour
{
    public string neededElement1;
    public string neededElement2;
    public Sprite icon;
    public OximoronSlot[] slots = new OximoronSlot[4
        ];
    public int charges;
    public float cooldown;
    public float time;

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void ClearSlot()
    {
        slots[CompanionInventory.Instance.index].ClearSlot();
        slots[CompanionInventory.Instance.index] = null;
    }
    
    public void ResetCoolDown()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                slots[i].equipedOximoron.time = 0;
            }
        }
    }
}
