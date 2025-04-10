using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxymorones : MonoBehaviour
{
    [SerializeField] public bool OxymoronComp = false; //Booleano que me permite saber si el Oxymoron se completo.
    [SerializeField] public bool OxyPartOne = false; //Booleano que me permite saber si ya se interactuo con un elemento que forma el oxymoron (pasar a acompanante).
    [SerializeField] public bool OxyPartTwo = false; //Booleano que me permite saber si ya se interactuo con un elemento que forma el oxymoron (Pasar a acompanante).
    [SerializeField] public int InteractDis; //Distancia usada para que suceda la interaccion entre personaje y elemento.
    [SerializeField] public GameObject Character; //Leif, que se va a usar para medir la medida entre el oxymoron o el elemento.
    [SerializeField] public GameObject Weapon; //Espada (pasar a espada).
    [SerializeField] public GameObject Companion; //Companero (pasar a acompanante).
    [SerializeField] public GameObject ElementOne; //Elemento1 (pasar a acompanante).
    [SerializeField] public GameObject ElementTwo; //Elemento2 (pasar a acompanante).

    void Update() //Lo pasamos a acompanante.
    {
        OxyConfirm(); //Funcion que me va a confirmar cuando Leif haya interactuado con 2 elementos.
        OxyCheck(); //Funcion que me va a confirmar cuando Leif interactue con un elemento deseado para formar el Oxymoron.
    }

    private void OxyConfirm() //(lo pasamos a acompanante).
    {
        if (OxyPartOne && OxyPartTwo)
        {
            OxymoronComp = true;
        }
    }

    private void OxyCheck() //(Lo pasamos a acompanante).
    {
        if (!OxyPartOne && Vector3.Distance(Character.transform.position, ElementOne.transform.position) <= InteractDis) //Distancia Medida con InteractDis.
        {
            OxyPartOne = true;
        }

        if (!OxyPartTwo && Vector3.Distance(Character.transform.position, ElementTwo.transform.position) <= InteractDis) //Distancia Medida con InteractDis.
        {
            OxyPartTwo = true;
        }
    }
}
