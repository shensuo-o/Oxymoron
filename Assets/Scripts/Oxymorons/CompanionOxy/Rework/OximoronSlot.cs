using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OximoronSlot : MonoBehaviour
{
    public Image element1;
    public Image element2;
    public Image oximoronIcon;

    [SerializeField] public Element[] elements = new Element[2];

    public Oximorons equipedOximoron;

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
                OximoronInventory.Instance.allOximorons[i].slot = this;
                oximoronIcon.sprite = equipedOximoron.icon;

                return;
            }
        }
        return;
    }

    public void ClearSlot()
    {
        oximoronIcon.sprite = null;
        element1.sprite = null;
        element2.sprite = null;
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i] = null;
        }
        equipedOximoron = null;
    }
}
