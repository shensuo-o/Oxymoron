using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OxiInventory : MonoBehaviour
{
    public GameObject[] Oximorones = new GameObject[20]; //Oximorones conseguidos
    private int indexInv = 0;

    public GameObject[] Equiped = new GameObject[4]; //Oximorones equipados para uso
    private int indexEquip = 0;

    public void AddOximoron(GameObject oximoron) //Añade un oximoron al inventario, lo llamaria el GameManager o el objeto que sea que trigeree el evento de desbloquear un oximoron.
    {
        Oximorones[indexInv] = oximoron;
        indexInv++;
    }

    public void EquipOximoron(GameObject oximoron)//Lo llama un boton en el menu, el oximoron seleccionado cambiaria segun el seleccionado en ekl menu.
    {
        Equiped[indexEquip] = oximoron;
    }

    public void SelectSlot(int slot)//Se llama cuando se selecciona el slot donde el jugador quiere equipar el nuevo oximoron.
    {
        indexEquip = slot;
    }
}
