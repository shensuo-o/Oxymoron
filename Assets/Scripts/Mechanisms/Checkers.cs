using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkers : MonoBehaviour
{
    public GameManager GameManager;
    public string Trigger;
    public bool isWater;

    private void OnTriggerEnter(Collider other)
    {
        if (Trigger == "CuboAmarillo")
        {
            GameManager.CheckAmarillo = true;    
         }   

        if (Trigger == "CuboRojo")
        {    
            GameManager.CheckRojo = true;    
        }        

        if (Trigger == "CuboVerde")    
        {    
            GameManager.CheckVerde = true;    
        }    

            if (Trigger == "CuboRosa")
            {
                GameManager.CheckRosa = true;
            }

            if (Trigger == "AttackDetection" && !isWater)
            {
                GameManager.Finish = true;
            }

            if (Trigger == "AttackDetection" && isWater)
            {
                GameManager.Death = true;
            }    
    }
}
