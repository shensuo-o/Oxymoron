using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class OxyCompanion : Oxymorones
{
    [SerializeField] public bool OxyPartOne = false; //Booleano que me permite saber si ya se interactuo con un elemento que forma el oxymoron.
    [SerializeField] public bool OxyPartTwo = false; //Booleano que me permite saber si ya se interactuo con un elemento que forma el oxymoron.
    [SerializeField] public GameObject Companion; //Companero.
    [SerializeField] public GameObject ElementOne; //Elemento1.
    [SerializeField] public GameObject ElementTwo; //Elemento2.

    protected virtual void Update() //Lo pasamos a acompanante.
    {
        OxyConfirm(); //Funcion que me va a confirmar cuando Leif haya interactuado con 2 elementos.
        OxyCheck(); //Funcion que me va a confirmar cuando Leif interactue con un elemento deseado para formar el Oxymoron.
        CheckQ(); //Verifica cuando se usa la habilidad de oxymoron
    }

    private void OxyConfirm()
    {
        if (OxyPartOne && OxyPartTwo)
        {
            OxymoronComp = true;
        }
    }

    private void OxyCheck()
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
    protected virtual void CheckQ()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Q))
        {
            Action();
        }
    }
}
