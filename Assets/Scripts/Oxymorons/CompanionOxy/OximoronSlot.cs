using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OximoronSlot : MonoBehaviour
{
    [ColorUsage(hdr: true, showAlpha: true)]

    public Image element1;
    public Image element2;
    public Image oximoronIcon;

    [SerializeField] private Sprite defaultOxiIcon;
    [SerializeField] private Sprite defaultElemIcon;

    public Element[] elements = new Element[2];

    public Oximorons equipedOximoron;
    public bool CanRecieveElement;

    [SerializeField] private Material slotMaterial;

    private void Start()
    {
        slotMaterial.SetTexture("_Icon", null);
        slotMaterial.SetColor("_OximoronColor", Color.black);
    }

    public void ShowElement()
    {

        if (elements[0] != null)
        {
            element1.sprite = elements[0].icon;
        }

        if (elements[1] != null)
        {
            element2.sprite = elements[1].icon;
        }
    }

    public void EquipOximoron()
    {
        for (int i = 0; i < OximoronInventory.Instance.allOximorons.Length; i++)
        {
            if ((OximoronInventory.Instance.allOximorons[i].neededElement1 == elements[0].elementType || 
                OximoronInventory.Instance.allOximorons[i].neededElement1 == elements[1].elementType) && 
                (OximoronInventory.Instance.allOximorons[i].neededElement2 == elements[0].elementType || 
                OximoronInventory.Instance.allOximorons[i].neededElement2 == elements[1].elementType))
            {
                equipedOximoron = OximoronInventory.Instance.allOximorons[i];
                OximoronInventory.Instance.allOximorons[i].gameObject.SetActive(true);
                OximoronInventory.Instance.allOximorons[i].charges++;
                OximoronInventory.Instance.allOximorons[i].slots[CompanionInventory.Instance.index] = this;
                oximoronIcon.sprite = equipedOximoron.icon;
                slotMaterial.SetTexture("_Icon", equipedOximoron.companionIcon);
                slotMaterial.SetColor("_OximoronColor", equipedOximoron.iconColor * 2);

                return;
            }
        }
        return;
    }

    public void ClearSlot()
    {
        oximoronIcon.sprite = defaultOxiIcon;
        slotMaterial.SetTexture("_Icon", null);
        slotMaterial.SetColor("_OximoronColor", Color.black);
        element1.sprite = defaultElemIcon;
        element2.sprite = defaultElemIcon;
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i] = null;
        }
        equipedOximoron = null;
        CompanionInventory.Instance.leifSword.ResetEffects();
    }
}
