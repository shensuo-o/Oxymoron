using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TakeElement : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private CompanionInventory inventory;
    [SerializeField] private string can;
    [SerializeField] private string canNot;
    [SerializeField] private GameObject foundElement;
    [SerializeField] public bool elementFound;

    private void Update()
    {
        if (elementFound)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                prompt.SetActive(false);
                inventory.AddElement(foundElement.GetComponent<Element>());
                foundElement.SetActive(false);
                elementFound = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            prompt.SetActive(true);
            if (inventory.TakenElements.Count >= 2)
            {
                prompt.gameObject.GetComponent<TextMeshProUGUI>().text = canNot;
            }
            else
            {
                foundElement = other.gameObject;
                prompt.gameObject.GetComponent<TextMeshProUGUI>().text = can;
                elementFound = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            prompt.SetActive(false);
            elementFound = false;
        }
    }
}
