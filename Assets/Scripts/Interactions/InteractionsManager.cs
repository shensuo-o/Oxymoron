using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    public static InteractionsManager Instance { get; private set; }
    public GameObject[] Elements; //Array de tutoriales.
    public int index;

    void Awake()
    {
        Instance = this;
        index = 1;
    }
}
