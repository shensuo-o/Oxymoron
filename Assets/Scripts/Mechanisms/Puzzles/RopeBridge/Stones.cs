using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    public OpenBridge bridge;
    public int ID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            if(other.gameObject.GetComponent<Whirlwind>() != null)
            {
                Debug.Log("Touched a stone.");
                bridge.StoneMoved(ID);
            }
        }
    }
}
