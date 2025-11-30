using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTutorial : MonoBehaviour
{
    public GameObject text;
    public TextMeshProUGUI textMesh;
    public GameObject cuadro;
    public string message;
    public float delay = 0.05f;
    //public AnimationClip readClip;

    public Coroutine typeTextCo;

    /*public CompanionMovement comp;
    public CompanionAnimations companionAnimations;
    public GameObject animTarget;
    public GameObject tempTarget;*/

    void Start()
    {
        textMesh = text.GetComponent<TextMeshProUGUI>();
        //comp = GameObject.Find("Companion").GetComponent<CompanionMovement>();
    }

    IEnumerator TypeText()
    {
        foreach (char character in message.ToCharArray())
        {
            textMesh.text += character;
            yield return new WaitForSeconds(delay);
        }
    }

    /*private IEnumerator CompStartReading(bool set)
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
    }*/

    private void OnTriggerEnter(Collider other)
    {
        cuadro.SetActive(true);
        text.SetActive(true);
        typeTextCo = StartCoroutine(TypeText());
        //StartCoroutine(CompStartReading(true));
    }

    private void OnTriggerExit(Collider other)
    {
        cuadro.SetActive(false);
        text.SetActive(false);
        StopCoroutine(typeTextCo);
        textMesh.text = " ";
        //tartCoroutine(CompStartReading(false));
        //comp.target = tempTarget;
    }
}
