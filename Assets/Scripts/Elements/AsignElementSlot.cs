using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignElementSlot : MonoBehaviour
{
    public string ElementType;
    public DetectElement detector;
    public Slots slot;

    private void Update()
    {
        ElementType = detector.type;
    }
    public void AsignElement()
    {
        for (int i = 0; i < slot.elements.Length; i++)
        {
            if (slot.elements[i] == null)
            {
                if (IsCombValid() == true)
                {
                    slot.elements[i] = ElementType;
                    Time.timeScale = 1;
                    return;
                }
            }
        }
    }

    public bool IsCombValid()
    {
        if (slot.elements[0] == null)
        {
            Debug.Log("Asigned element.");
            return true;
        }
        else if (ElementType == slot.elements[0])
        {
            Debug.Log("Cant have the same element twice in 1 slot.");
            return false;
        }
        else if (ElementType == "Fire" && slot.elements[0] == "Space")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else if (ElementType == "Space" && slot.elements[0] == "Fire")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else if (ElementType == "Ice" && slot.elements[0] == "Space")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else if (ElementType == "Space" && slot.elements[0] == "Ice")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else if (ElementType == "Ice" && slot.elements[0] == "Darkness")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else if (ElementType == "Darkness" && slot.elements[0] == "Ice")
        {
            Debug.Log("Cant mix those elements.");
            return false;
        }
        else
        {
            Debug.Log("Asigned element.");
            return true;
        }
    }
}
