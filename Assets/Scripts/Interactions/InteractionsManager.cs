using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    public static InteractionsManager Instance { get; private set; }
    public GameObject[] Tutorials; //Array de tutoriales.
    public int index;

    void Awake()
    {
        Instance = this;
        index = 1;
    }

    public void SetNext() //Activa el siguiente tutorial en el array de tutoriales.
    {
        Tutorials[index].SetActive(true);
        index++;
    }
}
