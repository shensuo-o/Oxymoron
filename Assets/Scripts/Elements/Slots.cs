using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public string[] elements;
    public Image element1;
    public Image element2;
    public Color fire;
    public Color ice;
    public Color darkness;
    public Color space;
    public Image icon;

    private void Start()
    {
        elements = new string[2];
    }

    void Update()
    {
        if (elements[0] == "Fire")
        {
            element1.color = fire;
        }
        if (elements[1] == "Fire")
        {
            element2.color = fire;
        }

        if (elements[0] == "Ice")
        {
            element1.color = ice;
        }
        if (elements[1] == "Ice")
        {
            element2.color = ice;
        }

        if (elements[0] == "Darkness")
        {
            element1.color = darkness;
        }
        if (elements[1] == "Darkness")
        {
            element2.color = darkness;
        }

        if (elements[0] == "Space")
        {
            element1.color = space;
        }
        if (elements[1] == "Space")
        {
            element2.color = space;
        }

        if (elements[0] == "Fire" || elements[1] == "Fire" && elements[0] == "Ice" || elements[1] == "Ice")
        {
            icon.color = Color.cyan;
        }

        if (elements[0] == "Fire" || elements[1] == "Fire" && elements[0] == "Darkness" || elements[1] == "Darkness")
        {
            icon.color = Color.yellow;
        }

        if (elements[0] == "Space" || elements[1] == "Space" && elements[0] == "Darkness" || elements[1] == "Darkness")
        {
            icon.color = Color.blue;
        }
    }
}
