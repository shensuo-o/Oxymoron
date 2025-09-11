using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public Statue estatua;
    public GameObject text;
    public string numero;
    public string message;

    private void Start()
    {
        if (estatua.index == 0)
        {
            numero = "El primero ";
        }
        else if (estatua.index == 1)
        {
            numero = "El segundo ";
        }
        else if (estatua.index == 2)
        {
            numero = "El tercero ";
        }
        else
        {
            numero = "El cuarto";
        }
        text.GetComponent<TextMeshProUGUI>().text = numero + message;
    }

    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
