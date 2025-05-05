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

    public GameObject companion;

    public Color LightGrey;

    private void Start()
    {
        elements = new string[2];
        LightGrey = new Color (113f, 113f, 113f, 255f);
    }

    public void Show()
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

        if (elements[0] == "Fire" && elements[1] == "Ice") 
        {
            icon.color = Color.cyan;
            companion.GetComponent<CastColdFire>().charges++;
        }
        else if(elements[1] == "Fire" && elements[0] == "Ice")
        {
            icon.color = Color.cyan;
            companion.GetComponent<CastColdFire>().charges++;
        }
        else if (elements[0] == "Fire" && elements[1] == "Darkness")
        {
            icon.color = Color.yellow;
            companion.GetComponent<ShadowLight>().charges++;
        }
        else if (elements[1] == "Fire" && elements[0] == "Darkness")
        {
            icon.color = Color.yellow;
            companion.GetComponent<ShadowLight>().charges++;
        }
        else if (elements[0] == "Space" && elements[1] == "Darkness")
        {
            icon.color = Color.blue;
            companion.GetComponent<CastWhirlwind>().charges++;
        }
        else if (elements[1] == "Space" && elements[0] == "Darkness")
        {
            icon.color = Color.blue;
            companion.GetComponent<CastWhirlwind>().charges++;
        }
        else
        {
            icon.color= Color.grey;
        }
    }

    private void Update()
    {
        if (elements[0] == null)
        {
            element1.color = LightGrey;
        }
        if (elements[1] == null)
        {
            element2.color = LightGrey;
        }

        if (icon.color == Color.cyan && Input.GetKeyDown(KeyCode.Alpha2))
        {
            elements[0] = null;
            elements[1] = null;
            icon.color = Color.grey;
        }

        if (icon.color == Color.yellow && Input.GetKeyDown(KeyCode.Alpha1))
        {
            elements[0] = null;
            elements[1] = null;
            icon.color = Color.grey;
        }

        if (icon.color == Color.blue && Input.GetKeyDown(KeyCode.Alpha3))
        {
            elements[0] = null;
            elements[1] = null;
            icon.color = Color.grey;
        }
    }
}
