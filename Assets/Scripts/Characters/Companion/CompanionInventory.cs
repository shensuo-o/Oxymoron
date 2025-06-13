using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionInventory : MonoBehaviour
{
    public static CompanionInventory Instance { get; private set; }

    public OximoronSlot[] Slots;
    [SerializeField] public int index;
    [SerializeField] private Image SelectIndicator;

    [SerializeField] private TakeElement detector;

    [SerializeField] private GameObject errorPrompt;

    [SerializeField] private MeleeCombat leifSword;

    void Awake()
    {
        Instance = this;
        leifSword = GameObject.Find("Leif").GetComponent<MeleeCombat>();
    }

    private void Update()
    {
        SelectIndicator.transform.position = Slots[index].transform.position;

        var scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");

        if (Slots[index].CanRecieveElement == false)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[index].CanRecieveElement == false)
                {
                    index++;
                    if (index >= Slots.Length)
                    {
                        index = 0;
                    }
                }
            }
        }

        if (scrollInput > 0)
        {
            index++;
            if (index >= Slots.Length)
            {
                index = 0;
            }

            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[index].CanRecieveElement == false)
                {
                    index++;
                    if (index >= Slots.Length)
                    {
                        index = 0;
                    }
                }
            }

            leifSword.CheckStatus(index);
        }

        if (scrollInput < 0)
        {
            index--;
            if (index < 0)
            {
                index = 3;
            }

            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[index].CanRecieveElement == false)
                {
                    index--;
                    if (index < 0)
                    {
                        index = 3;
                    }
                }
            }
        }
    }

    public void EquipElement(Element element)
    {
        if (Slots[index].elements[0] == null)
        {
            Slots[index].elements[0] = element;
            Slots[index].ShowElement();
        }
        else if (Slots[index].elements[1] == null)
        {
            Slots[index].elements[1] = element;
            Slots[index].ShowElement();
            Slots[index].EquipOximoron();
        }
    }
}
