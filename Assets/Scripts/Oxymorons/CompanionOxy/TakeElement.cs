using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TakeElement : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private CompanionInventory inventory;
    [SerializeField] private Element foundElement;
    [SerializeField] private bool elementFound;
    [SerializeField] private float timer;
    [SerializeField] private float absorbTime;
    public List<OximoronSlot> abailableSlots;

    private void Update()
    {
        if (elementFound)
        {
            if (Input.GetKey(KeyCode.E) && abailableSlots.Count >= 1)
            {
                timer += Time.deltaTime;
                if (timer >= absorbTime)
                {
                    timer = 0;
                    inventory.EquipElement(foundElement);
                    foundElement.StartCoroutine("TurnOffAndOn");
                    foundElement = null;
                    elementFound = false;
                    abailableSlots.Clear();
                }
            }
        }
        else if (!elementFound)
        {
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                inventory.Slots[i].CanRecieveElement = true;
            }
        }
    }

    private void CheckSlots(Element element)
    {
        for (int i = 0; i < inventory.Slots.Length; i++)
        {
            if (inventory.Slots[i].elements[0] == null)
            {
                Debug.Log("vacio");
                inventory.Slots[i].CanRecieveElement = true;
                abailableSlots.Add(inventory.Slots[i]);
            }
            else if (inventory.Slots[i].elements[0].elementType == element.elementType)
            {
                Debug.Log("repetido");
                inventory.Slots[i].CanRecieveElement = false;
            }
            else if (inventory.Slots[i].elements[1] == null)
            {
                for (int n = 0; n < OximoronInventory.Instance.allOximorons.Length; n++)
                {
                    if ((OximoronInventory.Instance.allOximorons[n].neededElement1 == element.elementType || 
                        OximoronInventory.Instance.allOximorons[n].neededElement1 == inventory.Slots[i].elements[0].elementType) && 
                        (OximoronInventory.Instance.allOximorons[n].neededElement2 == element.elementType || 
                        OximoronInventory.Instance.allOximorons[n].neededElement2 == inventory.Slots[i].elements[0].elementType))
                    {
                        inventory.Slots[i].CanRecieveElement = true;
                        Debug.Log("es compatible");
                        abailableSlots.Add(inventory.Slots[i]);
                    }
                    else
                    {
                        if (inventory.Slots[i].CanRecieveElement == true)
                        {
                            continue;
                        }
                        Debug.Log("no es compatible");
                        inventory.Slots[i].CanRecieveElement = false;
                    }
                }
            }
            else
            {
                inventory.Slots[i].CanRecieveElement = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            foundElement = other.GetComponent<Element>();
            CheckSlots(other.GetComponent<Element>());
            elementFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            foundElement = null;
            elementFound = false;
            abailableSlots.Clear();
        }
    }
}
