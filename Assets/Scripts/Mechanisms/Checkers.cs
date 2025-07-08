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
            other.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }   

        if (Trigger == "CuboRojo")
        {    
            GameManager.CheckRojo = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }        

        if (Trigger == "CuboVerde")    
        {    
            GameManager.CheckVerde = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }    

        if (Trigger == "CuboRosa")
        {
            GameManager.CheckRosa = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }

        if (Trigger == "AttackDetection" && !isWater)
        {
            GameManager.Finish = true;
            SaveSpawn.Instance.transform.position = new Vector3(-274.44f, 3.02f, 0);
        }

        if (Trigger == "AttackDetection" && isWater)
        {
            GameManager.Death = true;
        }    
    }
}
