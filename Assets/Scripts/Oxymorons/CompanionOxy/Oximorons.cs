using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Oximorons : MonoBehaviour
{
    public string neededElement1;
    public string neededElement2;
    public Sprite icon;
    public Texture2D companionIcon;
    [ColorUsage(hdr: true, showAlpha: true)]
    public Color iconColor;
    public OximoronSlot[] slots = new OximoronSlot[4];
    public int charges;
    public float cooldown;
    public float time;
    public GameObject proyectile;
    public VisualEffect vfx;
    public Animator leif;

    public void PlayCast()
    {
        leif.SetTrigger("Cast");
        vfx.SetVector4("MagicColor", iconColor);
        vfx.Play();
    }

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
        for (int i = 0; i < CompanionInventory.Instance.Slots.Length; i++)
        {
            if (CompanionInventory.Instance.Slots[i].equipedOximoron != null)
            {
                CompanionInventory.Instance.Slots[i].equipedOximoron.time = 0;
                CompanionInventory.Instance.Slots[i].animator.SetTrigger("CoolDown");
            }
        }
    }
}
