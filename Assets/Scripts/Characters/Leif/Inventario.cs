using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    [SerializeField] private GameObject[] Items;
    [SerializeField] private int index;
    [SerializeField] private int ItemCount; //Cambiar cada vez que se agrega al juego un item.

    private void Awake()
    {
        index = 0;
        Items = new GameObject[ItemCount];
    }
    public void AddItem(GameObject item)
    {
        Items[index] = item;
    }
}
