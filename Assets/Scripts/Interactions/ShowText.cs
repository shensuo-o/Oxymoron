using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Statue estatua;
    public GameObject text;
    public TextMeshProUGUI textMesh;
    public string numero;
    public string message;
    public string fullMessage;
    public float delay = 0.05f;

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
        fullMessage = numero + message;
        textMesh = text.GetComponent<TextMeshProUGUI>();
    }

    IEnumerator TypeText()
    {
        foreach (char character in fullMessage.ToCharArray())
        {
            textMesh.text += character;
            yield return new WaitForSeconds(delay);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
        StartCoroutine(TypeText());
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        StopAllCoroutines();
        textMesh.text = " ";
    }
}
