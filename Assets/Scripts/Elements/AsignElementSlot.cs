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
            Debug.Log("1");
            return true;
        }
        else if (ElementType == slot.elements[0])
        {
            Debug.Log("2");
            return false;
        }
        else if (ElementType == "Fire" && slot.elements[0] == "Space")
        {
            Debug.Log("3");
            return false;
        }
        else if (ElementType == "Space" && slot.elements[0] == "Fire")
        {
            Debug.Log("4");
            return false;
        }
        else if (ElementType == "Ice" && slot.elements[0] == "Space")
        {
            Debug.Log("5");
            return false;
        }
        else if (ElementType == "Space" && slot.elements[0] == "Ice")
        {
            Debug.Log("6");
            return false;
        }
        else if (ElementType == "Ice" && slot.elements[0] == "Darkness")
        {
            Debug.Log("7");
            return false;
        }
        else if (ElementType == "Darkness" && slot.elements[0] == "Ice")
        {
            Debug.Log("8");
            return false;
        }
        else
        {
            Debug.Log("9");
            return true;
        }
    }
}
