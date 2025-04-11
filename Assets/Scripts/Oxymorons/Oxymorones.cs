using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oxymorones : MonoBehaviour
{
    [SerializeField] public bool OxymoronComp = false; //Booleano que me permite saber si el Oxymoron se completo.
    [SerializeField] public int InteractDis; //Distancia usada para que suceda la interaccion entre personaje y elemento.
    [SerializeField] public GameObject Character; //Leif, que se va a usar para medir la medida entre el oxymoron o el elemento.

    private void Update()
    {
        OxymoronReady();
    }

    private void OxymoronReady()
    {
        if (OxymoronComp)
        {
            gameObject.SetActive(true);
        }
    }
    protected virtual void Action()
    {
        Debug.Log("Oxymoron activado");
    }
}

