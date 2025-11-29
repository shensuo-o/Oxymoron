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
    public GameObject cuadro;
    public string numero;
    public string message;
    public string fullMessage;
    public float delay = 0.05f;
    public AnimationClip readClip;

    public Coroutine typeTextCo;

    public CompanionMovement comp;
    public CompanionAnimations companionAnimations;
    public GameObject animTarget;
    public GameObject tempTarget;

    private void Start()
    {
        StartCoroutine(GetIndex());
        textMesh = text.GetComponent<TextMeshProUGUI>();
        comp = GameObject.Find("Companion").GetComponent<CompanionMovement>();
    }

    IEnumerator GetIndex()
    {
        yield return new WaitForSeconds(1);

        if (estatua.index == 0)
        {
            numero = " el primero de los principes.";
        }
        else if (estatua.index == 1)
        {
            numero = " el segundo de los principes.";
        }
        else if (estatua.index == 2)
        {
            numero = " el tercero de los principies.";
        }
        else
        {
            numero = "el cuarto...";
        }
        fullMessage = message + numero;
    }
    
    IEnumerator TypeText()
    {
        foreach (char character in fullMessage.ToCharArray())
        {
            textMesh.text += character;
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator CompStartReading(bool set)
    {
        if (set == true)
        {
            tempTarget = comp.target;
            comp.target = animTarget;
            comp.distance = 0.5f;
            while (comp.rb.velocity.magnitude > 0)
            {
                yield return null;
            }
        }
        else if (set == false)
        {
           
            comp.target = tempTarget;
            comp.distance = 2;
            while (comp.rb.velocity.magnitude > 0)
            {
                yield return null;
            }
        }
        
        companionAnimations.PlayAnimation(readClip, set);
    }

    private void OnTriggerEnter(Collider other)
    {
        cuadro.SetActive(true);
        text.SetActive(true);
        typeTextCo = StartCoroutine(TypeText());
        StartCoroutine(CompStartReading(true));
    }

    private void OnTriggerExit(Collider other)
    {
        cuadro.SetActive(false);
        text.SetActive(false);
        StopCoroutine(typeTextCo);
        textMesh.text = " ";
        StartCoroutine(CompStartReading(false));
        comp.target = tempTarget;
    }
}
