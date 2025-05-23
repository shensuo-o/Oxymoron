using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DetectElement : MonoBehaviour
{
    public Slots[] Slots;
    public GameObject textE;
    public GameObject imageE;
    public GameObject nameE;
    public GameObject[] buttons;

    public Color fire;
    public Color ice;
    public Color darkness;
    public Color space;

    public string type;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            textE.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                type = other.GetComponentInParent<Element>().elementType;
                Time.timeScale = 0;
                imageE.SetActive(true);

                if (type == "Fire")
                {
                    imageE.GetComponent<Image>().color = fire;
                    nameE.GetComponent<TMPro.TextMeshProUGUI>().text = type;
                }

                if (type == "Ice")
                {
                    imageE.GetComponent<Image>().color = ice;
                    nameE.GetComponent<TMPro.TextMeshProUGUI>().text = type;
                }

                if (type == "Darkness")
                {
                    imageE.GetComponent<Image>().color = darkness;
                    nameE.GetComponent<TMPro.TextMeshProUGUI>().text = type;
                }

                if (type == "Space")
                {
                    imageE.GetComponent<Image>().color = space;
                    nameE.GetComponent<TMPro.TextMeshProUGUI>().text = type;
                }

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 14)
        {
            textE.SetActive(false);
            Time.timeScale = 1;
            imageE.SetActive(false);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
        }
    }
}
